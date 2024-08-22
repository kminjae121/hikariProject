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

        Chase();
        _fish.SpriteFlip(_fish.targetTrm.position);

        float distance = Vector2.Distance
            (_fish.targetTrm.position, _fish.transform.position);

        if (distance < _fish.attackRadius)
        {
            _stateMachine.ChangeState(FishStateEnum.Attack);
        }
        else if (_fish.BrightFoodHold.brightPlants.brightStep == 0)
        {
            _fish.isDark = true;
            _stateMachine.ChangeState(FishStateEnum.Move);
        }
        else if (distance > _fish.detectRadius + 2)
        {
            _stateMachine.ChangeState(FishStateEnum.Move);
        }
    }

    public void Chase()
    {
        Vector2 dir = _fish.targetTrm.position - _fish.transform.position;
        Vector2 moveDir = dir.normalized;

        _fish.RigidCompo.velocity = moveDir * (_fish.moveSpeed + 1);
    }
}
