using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnglerFishState : FishState
{
    protected FishEnemy _anglerFish;
    protected int _animBoolHash;

    public AnglerFishState(FishEnemy _onwer, StateMachine state, string animHashName) : base(_onwer, state, animHashName)
    {
        _anglerFish = _onwer;
        _animBoolHash = Animator.StringToHash(animHashName);
    }

    public override void Enter()
    {
        _fish.AnimCompo.SetBool(_animBoolHash, true);
    }

    public override void UpdateState()
    {

    }

    public override void Exit()
    {
        _fish.AnimCompo.SetBool(_animBoolHash, false);
    }
}
