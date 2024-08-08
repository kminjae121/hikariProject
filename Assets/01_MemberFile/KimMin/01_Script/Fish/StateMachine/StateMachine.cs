using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    public Dictionary<FishStateEnum, FishState> stateDic = new Dictionary<FishStateEnum, FishState>();
    public FishState CurrentState { get; private set; }

    private Fish _fish;
    
    public void Initialize(FishStateEnum state, Fish fish)
    {
        _fish = fish;
        CurrentState = stateDic[state];
        CurrentState.Enter();
    }

    public void ChangeState(FishStateEnum changeState)
    {
        CurrentState.Exit();
        CurrentState = stateDic[changeState];
        CurrentState.Enter();
    }

    public void AddState(FishStateEnum stateEnum, FishState state)
    {
        stateDic.Add(stateEnum, state);
    }
}
