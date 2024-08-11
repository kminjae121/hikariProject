using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    public FishState CurrentState { get; private set; }

    public Dictionary<FishStateEnum, FishState> stateDic = new Dictionary<FishStateEnum, FishState>();

    private FishSetting _fish;
    
    public void Initialize(FishStateEnum state, FishSetting fish)
    {
        _fish = fish;

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
