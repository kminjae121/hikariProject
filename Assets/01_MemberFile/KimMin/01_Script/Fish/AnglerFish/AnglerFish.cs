using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FishStateEnum
{
    Move,
    Chase,
    Attack
}

public class AnglerFish : FishSetting
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

    public override void AnimationEndTrigger()
    {
        _stateMachine.CurrentState.AnimationEndTrigger();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, detectRadius); //감지 범위

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, detectRadius + 2); //체이스 탈출 범위

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius); //공격 범위
    }
}
