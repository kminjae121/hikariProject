using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnglerFishMoveState : FishState
{
    public AnglerFishMoveState(FishEnemy _onwer, StateMachine state, string animHashName) : base(_onwer, state, animHashName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("¹«ºù¸Ç");
    }

    public override void UpdateState()
    {
        base.UpdateState();

        float distance = Vector2.Distance
            (_fish.targetTrm.position, _fish.transform.position);

        if (Input.GetKeyDown(KeyCode.C))
        {
            _stateMachine.ChangeState(FishStateEnum.Chase);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
