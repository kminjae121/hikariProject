using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnglerFishAttackState : AnglerFishState
{
    public AnglerFishAttackState(FishSetting _onwer, StateMachine state, string animHashName) : base(_onwer, state, animHashName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void UpdateState()
    {
        base.UpdateState();

        if (_endTriggerCalled)
        {
            _stateMachine.ChangeState(FishStateEnum.Move);
        }
    }
}
