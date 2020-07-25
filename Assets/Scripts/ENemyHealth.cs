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
    //public int greenHit;
    public int gHitCount;
    //public AudioClip redDamage;
    //public AudioClip greenDamage;


    #region

    #endregion



    private void Awake()
    {
        anim = GetComponent<Animator>();
        currHealth = 4;
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
        gHitCount = 0;
    }

    public override void TakeDamage(float damageAmount)
    {
        GetComponent<Animator>().SetTrigger("isHit");
        base.TakeDamage(damageAmount);
        GetComponent<Animator>().ResetTrigger("isHit");
        if (currHealth <= 0)
        {
            eSpawner.enemyCount++;
            eSpawner.streakCount++;
            eSpawner.KillStreak();
            //pointTimer++;
            eSpawner.killCount++;
            GameManager.gameManager.hits++;
            eSpawner.SpawnGreen();
            CallMulti();
            //DeathEffect();
            Audiomanager.audiomanager.Play("RedDeath");
            Destroy(gameObject);
        }
        else
        {
            Audiomanager.audiomanager.Play("RedDamage");
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
        if (gHitCount >= 3)
        {
            if (Damage.damage.playerHealth >= 1)
            {
                Damage.damage.playerHealth = 0;
            }
            else if (Damage.damage.playerHealth == 0)
            {

                Damage.damage.PlayerDeath();
                Damage.damage.playerHealth -= GameManager.gameManager.enemyATK;
            }
        }
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
            TakeDamage(GunTestVR.gunTestVR.damageValue);
            //AudioSource.PlayClipAtPoint(redDamage, transform.position, 1f);
            enemyHit = true;
        }
        else if (collision.collider.CompareTag("GreenBullet") && gameObject.tag == "GreenEnemy")
        {
            //AudioSource.PlayClipAtPoint(greenDamage, transform.position, 1f);
            Audiomanager.audiomanager.Play("GreenDamage");
            enemyHit = true;
            GameManager.gameManager.greenDeaths++;                             
            Damage.damage.playerHealth += 100;
            Damage.damage.playerHealth = Mathf.Clamp(Damage.damage.playerHealth, 0, 100);
            //GunTestVR.gunTestVR.RegainAmmo();
            GameManager.gameManager.AmmoGain();
            GameManager.gameManager.RECHARGE();
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
            gHitCount++;
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

            if (pointTimer > GameManager.gameManager.pD2 && pointTimer < GameManager.gameManager.pDA2)
            {
               
                points = 75;
                scoreS.Multi(points);
            }

            if (pointTimer > GameManager.gameManager.pD3 && pointTimer < GameManager.gameManager.pDA3)
            {
               points = 50;
               scoreS.Multi(points);
              
            }
            if (pointTimer > GameManager.gameManager.pD4)
            {
              points = 25;
              scoreS.Multi(points);
             
            }
        }
}
     

