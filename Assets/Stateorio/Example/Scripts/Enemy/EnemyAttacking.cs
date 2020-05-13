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
	public int Strength;
    public Material yellowMat;
    public Material redMat;
    public Renderer NormMat;
    public NavMeshAgent agent;
	public Transform PlayerHealth;
    public Vector3 place;
	private float cntdwn;

	// Use this for initialization
	void Awake() 
    {
        Cooldown = 10;
        agent = GetComponent<NavMeshAgent>();
		cntdwn = Cooldown;
        NormMat = GetComponentInChildren<Renderer>();
 
	}
	
	// Update is called once per frame
	void Update () 
    {
        cntdwn -= Time.deltaTime;

        if (cntdwn <= 0) 
        {
            NormMat.material = yellowMat;
            agent.SetDestination(PlayerHealth.transform.position);
            transform.LookAt(PlayerHealth.transform);
            agent.stoppingDistance = 7;
            place = transform.position;
            
            Invoke("Attack", 3);
		}
	}

    void Attack()
    {
        //agent.isStopped = true;
        yellowMat = redMat;
        agent.SetDestination(place);
    }
}