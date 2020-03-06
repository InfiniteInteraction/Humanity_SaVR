using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StateMachine : MonoBehaviour
{
    private Dictionary<Type, BaseState> _availableStates;
    public BaseState CurrentState { get; private set; }
    public event Action<BaseState> OnStateChanged;

    public void SetStates(Dictionary<Type, BaseState> states)
    {
        _availableStates = states;
    }

    private void Update()
    {
        if(CurrentState == null)
        {
            CurrentState = _availableStates.Values.fir
        }
    }
}
