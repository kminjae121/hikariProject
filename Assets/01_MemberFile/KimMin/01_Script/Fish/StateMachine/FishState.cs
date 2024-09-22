using System;
using UnityEngine;

public class FishState
{
    protected FishSetting _fish;
    protected StateMachine _stateMachine;

    protected int _animBoolHash;
    protected bool _endTriggerCalled;

    public FishState(FishSetting _onwer, StateMachine state, string animHashName)
    { 
        _fish = _onwer;
        _stateMachine = state;
        _animBoolHash = Animator.StringToHash(animHashName);
    }


    public virtual void UpdateState()
    {

    }

    public virtual void Enter()
    {
        _fish.AnimCompo.SetBool(_animBoolHash, true);
        _endTriggerCalled = false;

    }
    public virtual void Exit()
    {
        _fish.AnimCompo.SetBool(_animBoolHash, false);
    }

    public void AnimationEndTrigger()
    {
        _endTriggerCalled = true;
    }
}