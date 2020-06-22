using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


/// <summary>
/// State in which enemy attacks the player (more like drains his HP).
/// If you look at this state in the FsmCore component of the enemy,
/// you will see it has two transition rules, one of which has a larger priority.
/// This is important, if enemy doesn't see the player, he shouldn't be able to chase him.
/// </summary>
public class EnemyAttacking : FsmState {

	public float Cooldown;
	public float Strength;
    public Material yellowMat;
    public Material redMat;
    public Renderer NormMat;
    public NavMeshAgent agent;
	[SerializeField] private Transform Player;
    public Vector3 place;
	private float cntdwn;
    public float atkTime;
    public float atkCooldown;

    [SerializeField] private Animator anim;

	// Use this for initialization
	void Awake() 
    {
        Strength = GameManager.gameManager.enemyATK;
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        Cooldown = GameManager.gameManager.CTime;
        atkCooldown = GameManager.gameManager.enemyATKCooldown;
        agent = GetComponent<NavMeshAgent>();
		cntdwn = Cooldown;
        atkTime = atkCooldown;
        NormMat = GetComponentInChildren<Renderer>();
        anim = GetComponent<Animator>();
 
	}
	
	// Update is called once per frame
	void Update () 
    {
        cntdwn -= Time.deltaTime;

        if (cntdwn <= 0) 
        {
            NormMat.material = yellowMat;
            agent.SetDestination(Player.transform.position);
            transform.LookAt(Player.transform);
            agent.stoppingDistance = 7;
            place = transform.position;
            
            Invoke("Attack", 3);
		}
	}

    void Attack()
    {
        atkTime -= Time.deltaTime;
        //agent.isStopped = true;
        yellowMat = redMat;
        
        GetComponent<Animator>().SetBool("isAttacking", true);
        GetComponent<Animator>().SetBool("isMoving", false);
        if((atkTime -=Time.deltaTime) <= 0)
        {
            atkTime = atkCooldown;
            ESpawner.eSpawner.streakCount = 0;
            Damage.damage.playerHealth -= Strength;
            //Audiomanager.audiomanager.Play("PlayerHurt");
            Damage.damage.PlayerDeath();
        }
    }
}