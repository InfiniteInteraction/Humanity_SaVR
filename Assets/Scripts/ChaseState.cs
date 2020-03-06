using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ChaseState : BaseState
{
    private EnemyMovement _EM;

    public ChaseState(EnemyMovement EM): base(EM.gameObject)
    {
        _EM = EM;
    }

    public override Type Tick()
    {
        if(_EM.player == null)
            return typeof()
    }

}