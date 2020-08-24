using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

public class EnemyMovement : MonoBehaviour
{
    public static EnemyMovement enemyMovement;
    public Rigidbody eRB;
    NavMeshAgent agent;
    public float stoppingDis;
    float timer;
    public float waitTime;
    public float retreatDis;
    [SerializeField]
    int stage;
    bool here;
    public Transform player;
    public GameObject greenPos;
    public Transform teleSpawn;
    public float fTimer;
    public float speed;
    Renderer rend;
    Color startColor;
    public Color midcolor;
    public Color endColor;
    public float trackDis;
    float t = 2;
    public int randomPath;
    public int randomPoint;
    public GameObject[] gotoPoints;
    public bool isChasingPlayer = true;


    public virtual void Awake()
    {
        enemyMovement = this;
        waitTime = 5f;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rend = GetComponentInChildren<Renderer>();
        startColor = rend.material.color;
        speed += 1.6f;
        eRB = GetComponent<Rigidbody>();
        gotoPoints = GameObject.FindGameObjectsWithTag("Points");
        stoppingDis = 10;
        randomPath = Random.Range(1, 3);
        randomPoint = Random.Range(0, 4);
        
    }
   
    public virtual void OnEnable()
    {
        timer = waitTime;
        agent = GetComponent<NavMeshAgent>();

        if(player == null)
        {
            player = FindObjectOfType<OVRPlayerController>().transform;
        }
        if(player == null)
        {
            player = FindObjectOfType<PlayerMovement>().transform;
        }
        here = false;
        stage = 0;
       
    }

    public virtual void Update()
    {
       trackDis = Vector3.Distance(transform.position, player.position);
        greenPos = GameObject.FindGameObjectWithTag("PPoint");
        transform.LookAt(player.transform);
        ChasePlayer();
        //Hurt();
        
    }


    public virtual void ChasePlayer()
    {
        if (isChasingPlayer)
        {
            if (tag == "RedEnemy" && Vector3.Distance(transform.position, player.position) > stoppingDis)
            {
                transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }
            else if (tag == "RedEnemy" && Vector3.Distance(transform.position, player.position) <= stoppingDis)
            {

                Hurt();
                here = true;
                
            }
            else if (tag == "GreenEnemy")
            {
                agent.SetDestination(greenPos.transform.position);
                Invoke("SpawnPass", 10);
            }
        }
        else
        {
            agent.SetDestination(gotoPoints[randomPoint].transform.position);
            return;
        }
    }


    public virtual void Hurt()
    {
        switch (stage)
        {
            case 0:
                if (here == true)
                {
                    stage = 1;                 
                }
                break;
            case 1:
                rend.material.color = Color.Lerp(rend.material.color, midcolor, 1 * Time.deltaTime);
                if (timer <= 0)
                {
                    stage = 2;
                    
                }
                else
                {
                    timer -= Time.deltaTime;
                    
                }
                break;
            case 2:
                rend.material.color = Color.Lerp(rend.material.color, endColor, 1 * Time.deltaTime);
                if (randomPath == 2)
                {
                    isChasingPlayer = false;
                    float newX = Mathf.Cos(t + 5);
                    float newZ = Mathf.Sin(t);

                    t += .02f;
                    transform.position = new Vector3(newX * 5, transform.position.y, newZ * Mathf.Cos(t + 5) + 6);
                }
                else
                {
                    stage = 3;
                }
                break;
            case 3:
                if (randomPath == 1)
                {
                    isChasingPlayer = false;
                }
                break;
           
        }
    }
    void SpawnPass()
    {
        Destroy(gameObject);
    }
}