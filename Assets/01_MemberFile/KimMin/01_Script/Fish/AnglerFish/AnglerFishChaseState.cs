using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnglerFishChaseState : FishState
{
    public AnglerFishChaseState(FishSetting _onwer, StateMachine state, string animHashName) : base(_onwer, state, animHashName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void UpdateState()
    {
        base.UpdateState();

        _fish.Chase();

        float distance = Vector2.Distance
            (_fish.targetTrm.position, _fish.transform.position);

        if (distance < _fish.attackRadius)
        {
            _stateMachine.ChangeState(FishStateEnum.Attack);
        }
        else if (distance > _fish.detectRadius + 2)
        {
            _stateMachine.ChangeState(FishStateEnum.Move);
        }
    }
}
