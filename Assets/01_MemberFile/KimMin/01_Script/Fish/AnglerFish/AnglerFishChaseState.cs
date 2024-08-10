using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnglerFishChaseState : FishState
{
    public AnglerFishChaseState(FishEnemy _onwer, StateMachine state, string animHashName) : base(_onwer, state, animHashName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("Chase");
    }
}
