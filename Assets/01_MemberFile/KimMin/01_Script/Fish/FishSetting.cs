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

    public bool isDark = false;

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
        BrightPlant.brightStep = 0;
    }

    public abstract void AnimationEndTrigger();
}
