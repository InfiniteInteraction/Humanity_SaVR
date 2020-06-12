using UnityEngine;

public class ENemyHealth : Health
{
    [SerializeField] private Animator anim;

    GunTestVR gtScript;
    UI_Info uiScript;
    public float pointTimer;
    public GameObject floatingTextPrefab;
    public ESpawner spawner;
    public ScoreScript scoreS;
    public ESpawner eSpawner;
    public int points;
    GameObject laserDeathEffect;
    GameObject gpDeathEffect;
    GameObject rpDeathEffect;
    Transform enemyPos;
    GameObject bulletType = null;
    public bool enemyHit;
    public static PlayerHealth pHealth;
    public Gun pewpew;
    public GameObject pointPopUp;
    GameObject canvas;
    public int greenHit;
    
    
    #region

    #endregion



    private void Awake()
    {
        anim = GetComponent<Animator>();
        currHealth = 10;
        if (gameObject.tag == ("GreenEnemy"))
        {
            currHealth = 1; 
        }
        spawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<ESpawner>();
        scoreS = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreScript>();
        eSpawner = FindObjectOfType<ESpawner>();
        uiScript = FindObjectOfType<UI_Info>();
        laserDeathEffect = Resources.Load(("Prefabs/EnemyDeathEffect"), typeof(GameObject)) as GameObject;
        gpDeathEffect = Resources.Load(("Prefabs/EnemyDeathGPEffect"), typeof(GameObject)) as GameObject;
        rpDeathEffect = Resources.Load(("Prefabs/EnemyDeathRPEffect"), typeof(GameObject)) as GameObject;
        pointTimer = 0;
        enemyHit = false;
        pHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        pewpew = FindObjectOfType<Gun>();
        
    }

    public override void TakeDamage(float damageAmount)
    {
        GetComponent<Animator>().SetTrigger("isHit");
        base.TakeDamage(damageAmount);
        GetComponent<Animator>().ResetTrigger("isHit");
        if (currHealth <= 0)
        {
            //if (gameObject.layer == 8 || gameObject.tag == "GreenEnemy")
            //{
            //    GameManager.gameManager.greenDeaths++;
            //}

            //if (gameObject.tag == "GreenEnemy")
            //{
            //    Damage.damage.playerHealth += 100;
            //    Damage.damage.playerHealth = Mathf.Clamp(Damage.damage.playerHealth, 0, 100);
            //    Destroy(gameObject);
            //    // pewpew.RegainAmmo();
            //}
            eSpawner.enemyCount++;
            eSpawner.streakCount++;
            eSpawner.KillStreak();
            pointTimer++;
            eSpawner.killCount++;
            GameManager.gameManager.hits++;
            eSpawner.SpawnGreen();
            CallMulti();
            //DeathEffect();
            Destroy(gameObject);
        }
        if (floatingTextPrefab)
        {
            // ShowFloatingText();
        }
    }

    void ShowFloatingText()
    {
        //var go = Instantiate(floatingTextPrefab, transform.position, Quaternion.identity, transform);
        //go.GetComponent<TextMesh>().text = damageTaken.ToString();
    }

    private void Update()
    {
        pointTimer += 1 * Time.deltaTime;
    }

    private void FixedUpdate()
    {
        enemyPos = transform;
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        bulletType = collision.collider.gameObject;
        if (collision.collider.CompareTag("RedBullet") && gameObject.tag == "RedEnemy")
        {
            TakeDamage(51);
            enemyHit = true;
        }
        else if (collision.collider.CompareTag("GreenBullet") && gameObject.tag == "GreenEnemy")
        {
            enemyHit = true;
            GameManager.gameManager.greenDeaths++;                             
            Damage.damage.playerHealth += 100;
            Damage.damage.playerHealth = Mathf.Clamp(Damage.damage.playerHealth, 0, 100);
            GunTestVR.gunTestVR.RegainAmmo();
            DeathEffect();
            CallMulti();
            eSpawner.KillStreak();
            Destroy(gameObject);  
        }
        if (collision.collider.CompareTag("GreenBullet") && gameObject.tag == "RedEnemy")
        {
            Damage.damage.playerHealth -= 1;
        }
        if (collision.collider.CompareTag("RedBullet") && gameObject.tag == "GreenEnemy")
        {
            Damage.damage.playerHealth -= 1;
            greenHit++;
            if(greenHit >= 3)
            {

                Damage.damage.PlayerDeath();

            }

        }
    }

    void DeathEffect()
    {
        if (bulletType.GetComponent<PlasmaBullet>())
        {
            if (gameObject.tag == "RedEnemy")
            {
                Instantiate(rpDeathEffect, enemyPos.position, Quaternion.identity);
            }
            if (gameObject.tag == "GreenEnemy")
            {
                Instantiate(gpDeathEffect, enemyPos.position, Quaternion.identity);
            }
        }
        //    else
        //    {
        //        Instantiate(laserDeathEffect, enemyPos.position, Quaternion.identity);
        //    }

        //    //int random = Random.Range(1, 4);
        //    //if (random == 1)
        //    //    Instantiate(deathEffect, enemyPos.position, Quaternion.identity);
        //    //if (random == 2)
        //    //if (random == 3)
        //    //else
        //    //    Instantiate(deathEffect, enemyPos.position, Quaternion.identity);

    }

        void CallMulti()
        {
            if (pointTimer < GameManager.gameManager.pD1)
            {
                points = 100;
                scoreS.Multi(points);
            }

            if (pointTimer > GameManager.gameManager.pD2 & pointTimer < GameManager.gameManager.pDA2)
            {
                points = 75;
                scoreS.Multi(points);
            }

            if (pointTimer > GameManager.gameManager.pD3 && pointTimer < GameManager.gameManager.pDA3)
            {
                points = 50;
                scoreS.Multi(points);
            }
            if (pointTimer < GameManager.gameManager.pD4)
            {
                points = 25;
                scoreS.Multi(points);
            }
        }
}
     

