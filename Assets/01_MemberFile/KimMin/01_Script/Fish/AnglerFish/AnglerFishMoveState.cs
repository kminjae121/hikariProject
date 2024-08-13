using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnglerFishMoveState : FishState
{
    public AnglerFishMoveState(FishSetting _onwer, StateMachine state, string animHashName) : base(_onwer, state, animHashName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        _fish.FindClosestWayPoint();
    }

    public override void UpdateState()
    {
        base.UpdateState();

        _fish.Move();

        float distance = Vector2.Distance
            (_fish.targetTrm.position, _fish.transform.position);

        if (distance < _fish.detectRadius && distance > _fish.attackRadius)
        {
            _stateMachine.ChangeState(FishStateEnum.Chase);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
