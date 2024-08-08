using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnglerFishMoveState : AnglerFishState
{
    public AnglerFishMoveState(Fish _onwer, StateMachine state, string animHashName) : base(_onwer, state, animHashName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void UpdateState()
    {
        base.UpdateState();

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
