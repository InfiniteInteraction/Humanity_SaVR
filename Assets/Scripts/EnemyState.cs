using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class EnemyState : MonoBehaviour
{
    private Dictionary<Type, BaseState> _availibleStates;
    public BaseState CurrentState { get; private set; }
    public event Action<BaseState> OnStateChanged;

    public void SetStates(Dictionary<Type, BaseState> states)
    {
        _availibleStates = states;
    }

    public void Update()
    {
        if (CurrentState == null)
        {
            CurrentState = _availibleStates.Values.First();
        }


        var nextState = CurrentState?.Tick();

        if ((nextState != null) && nextState != CurrentState?.GetType())
        {
            SwitchToNewState(nextState);
        }
    }

    void SwitchToNewState(Type nextState)
    {
        CurrentState = _availibleStates [nextState];
        OnStateChanged?.Invoke(CurrentState);
    }
}
