using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class State
{
    public Action OnEnter;

    public Action OnStay;

    public Action OnExit;
}

public class FSM<T> where T: Enum
{
    T _currentState;
    Dictionary<T, State> States;

    public FSM(T initialState)
    {
        States = new Dictionary<T, State>();
        foreach (T s in Enum.GetValues(typeof(T)))
        {
            States.Add(s, new State());
        }
        _currentState = initialState;
    }
    public void Update()
    {
        States[_currentState].OnStay?.Invoke();
    }

    public void ChangeState(T NewState)
    {
        States[_currentState].OnExit?.Invoke();
        States[NewState].OnEnter?.Invoke();

        _currentState = NewState;
    }

    public void SetOnEnter(T state, Action a)
    {
        States[state].OnEnter = a;
    }
    public void SetOnStay(T state, Action a)
    {
        States[state].OnStay = a;
    }
    public void SetOnExit(T state, Action a)
    {
        States[state].OnExit = a;
    }



}
