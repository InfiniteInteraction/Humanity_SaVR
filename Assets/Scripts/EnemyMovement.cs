using UnityEngine;
using UnityEngine.AI;
using System;
using System.Collections;
using System.Collections.Generic;

public class EnemyMovement : MonoBehaviour
{
    
    public Rigidbody eRB;
    NavMeshAgent agent;
    public float stoppingDis;
    float timer;
    public float waitTime;
    public float retreatDis;
    [SerializeField]
    int stage;
    bool here;
    public Transform player { get; private set; }
    public EnemyState EnemyState => GetComponent<EnemyState>();
    public GameObject greenPos;
    public Transform teleSpawn;
    public float fTimer;
    public float speed;
    Renderer rend;
    Color startColor;
    public Color midcolor;
    public Color endColor;
    public float trackDis;

    public virtual void Awake()
    {
        waitTime = 5f;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rend = GetComponentInChildren<Renderer>();
        startColor = rend.material.color;
        speed = 5f;
        eRB = GetComponent<Rigidbody>();
        InitializeStateMachine();
    }
    private void InitializeStateMachine()
    {
        var states = new Dictionary<Type, BaseState>()
        {
            typeof(ChaseState), new ChaseState(player: this)}
        } 
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
        ChasePlayer();
        Hurt();
        transform.LookAt(player.transform);
    }


    public virtual void ChasePlayer()
    {
        if (tag == "RedEnemy" && Vector3.Distance(transform.position, player.position) > stoppingDis)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else if (tag == "RedEnemy" && Vector3.Distance(transform.position, player.position) <= stoppingDis)
        {
            speed = 0;
            here = true;
        }

        else if (tag == "GreenEnemy")
        {
            agent.SetDestination(greenPos.transform.position);
            Invoke("SpawnPass", 10);
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
                break;
        }
    }
    void SpawnPass()
    {
        Destroy(gameObject);
    }
}