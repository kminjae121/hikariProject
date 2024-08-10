using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    public FishState CurrentState { get; private set; }

    public Dictionary<FishStateEnum, FishState> stateDic = new Dictionary<FishStateEnum, FishState>();

    private FishEnemy _fish;
    
    public void Initialize(FishStateEnum state, FishEnemy fish)
    {
        _fish = fish;

        foreach (var states in stateDic)
        {
            Debug.Log($"{states.Key} {states.Value}");
        }

        CurrentState = stateDic[state];
        CurrentState.Enter();
    }

    public void ChangeState(FishStateEnum newState)
    {
        CurrentState.Exit();
        CurrentState = stateDic[newState];
        CurrentState.Enter();
    }

    public void AddState(FishStateEnum stateEnum, FishState state)
    {
        stateDic.Add(stateEnum, state);
    }
}
