using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FishSetting : Fish
{
    public float detectRadius;
    public float attackRadius;
    public float moveSpeed;

    public Transform targetTrm;
    public Transform[] way;

    public Transform _targetWay;

    protected override void Awake()
    {
        base.Awake();
    }

    public void Chase()
    {
        Vector2 dir = targetTrm.position - transform.position;
        Vector2 moveDir = dir.normalized;

        RigidCompo.velocity = moveDir * (moveSpeed + 1);
    }

    public void Attack()
    {
        //빛 생기면 추가 예정
    }

    public abstract void AnimationEndTrigger();
}
