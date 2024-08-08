using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnglerFish : FishEnemy
{
    public StateMachine _stateMachine;

    protected override void Awake()
    {
        base.Awake();

        _stateMachine.AddState(FishStateEnum.Move, new AnglerFishState(this, _stateMachine, "Move"));
        _stateMachine.AddState(FishStateEnum.Chase, new AnglerFishState(this, _stateMachine, "Chase"));
        _stateMachine.AddState(FishStateEnum.Attack, new AnglerFishState(this, _stateMachine, "Attack"));

        _stateMachine.ChangeState(FishStateEnum.Move);
    }

    private void Update()
    {
        _stateMachine.CurrentState.UpdateState();
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, detectRadius);
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(transform.position, detectRadius + 2);
        Gizmos.color = Color.white;
    }
}
