using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ENemyGreenMovement : EnemyMovement
{
    public override void Awake()
    {
        base.Awake();
    }

    public override void OnEnable()
    {
        base.OnEnable();
        player = GameObject.FindGameObjectWithTag("PPoint").transform;
    }

    public override void Update()
    {
        base.Update();
    }

    public override void ChasePlayer()
    {
        base.ChasePlayer();
    }

    public override void Hurt()
    {

    }
}
