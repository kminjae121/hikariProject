using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FishStateEnum
{
    Move,
    Chase,
    Attack
}

public class AnglerFish : FishEnemy
{
    public StateMachine _stateMachine;

    protected override void Awake()
    {
        base.Awake();
        _stateMachine = new StateMachine();

        _stateMachine.AddState(FishStateEnum.Move, new AnglerFishMoveState(this, _stateMachine, "Move"));
        _stateMachine.AddState(FishStateEnum.Chase, new AnglerFishChaseState(this, _stateMachine, "Chase"));
        _stateMachine.AddState(FishStateEnum.Attack, new AnglerFishAttackState(this, _stateMachine, "Attack"));

        _stateMachine.Initialize(FishStateEnum.Move, this);
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
