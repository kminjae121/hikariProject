using System;
using UnityEngine;

public class FishState
{
    protected Fish _fish;
    protected int _animBoolHash;
    protected StateMachine _stateMachine;
    protected bool _endTriggerCalled;

    public FishState(Fish _onwer, StateMachine state, string animHashName)
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
        _fish.animCompo.SetBool(_animBoolHash, true);
        _endTriggerCalled = false;

    }
    public virtual void Exit()
    {
        _fish.animCompo.SetBool(_animBoolHash, false);
    }

    public void AnimationEndTrigger()
    {
        _endTriggerCalled = true;
    }
}