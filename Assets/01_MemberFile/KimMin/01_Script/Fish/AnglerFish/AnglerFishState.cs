using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnglerFishState : FishState
{
    protected FishEnemy _anglerFish;

    public AnglerFishState(FishEnemy _onwer, StateMachine state, string animHashName) : base(_onwer, state, animHashName)
    {
        _anglerFish = _onwer;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void UpdateState()
    {
        base.UpdateState();
    }

    public override void Exit()
    {
        base.Exit();
    }
}
