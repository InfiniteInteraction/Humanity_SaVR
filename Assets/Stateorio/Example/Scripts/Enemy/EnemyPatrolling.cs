using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// State in which the enemy goes through its patrol points.
/// When transitioning back to this state, the enemy continues its patrol route where he left of.
/// </summary>
[RequireComponent (typeof (NavMeshAgent))]
public class EnemyPatrolling : FsmState {

    [SerializeField] private Animator anim;

    public PatrolPoint[] Points;
	public float Epsilon = 0.5f;

	private int destPoint;
	private NavMeshAgent agent;

	private Vector3? returnPoint = null;

	void Awake () 
    {
        anim = GetComponent<Animator>();
		agent = GetComponent<NavMeshAgent> ();
        Points = GameObject.FindObjectsOfType<PatrolPoint>();
        destPoint = Random.Range(0, 6);
		if (Points.Length > 1) agent.autoBraking = false;
        agent.speed = GameManager.gameManager.eSpeed;
	}

	private void gotoNextPoint () {
		if (Points.Length == 0)
			return;

		if (returnPoint != null) {
			agent.destination = returnPoint.Value;
			returnPoint = null;
            GetComponent<Animator>().SetBool("isIdle", true);
            GetComponent<Animator>().SetBool("isMoving", false);
		} else {
			agent.destination = Points [destPoint].Position;
			destPoint = (destPoint + Random.Range(1,6)) % Points.Length;
            GetComponent<Animator>().SetBool("isMoving", true);
            GetComponent<Animator>().SetBool("isIdle", false);
		}
	}

	// Update is called once per frame
	void Update () {
		if (GameManager.gameManager.pause.isPaused == false)
		{
			agent.isStopped = false;
			GetComponent<Animator>().SetBool("isMoving", true);
			GetComponent<Animator>().SetBool("isIdle", false);
			if (Points.Length > 1 && !agent.pathPending && agent.remainingDistance < Epsilon)
			{
				gotoNextPoint();
			}			
		}
		else
		{
			GetComponent<Animator>().SetBool("isIdle", true);
			GetComponent<Animator>().SetBool("isMoving", false);
			agent.isStopped = true;
		}
	}

	public override void OnStateEnter () {
		gotoNextPoint ();
	}

	public override void OnStateLeave () {
		if (Points.Length == 0)
			return;
		
		agent.ResetPath ();

		if (Points.Length > 1)
			destPoint = destPoint > 0 ? destPoint - 1 : Points.Length - 1;

		returnPoint = transform.position;
	}
}
