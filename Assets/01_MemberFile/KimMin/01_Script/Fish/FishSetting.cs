using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FishSetting : Fish
{
    public int wayCount;
    public float detectRadius;
    public float attackRadius;
    public float moveSpeed;

    public Transform targetTrm;
    public Transform[] way;
    public Vector3 moveDir;

    private Transform _targetWay;

    protected override void Awake()
    {
        base.Awake();
    }

    public void Move()
    {
        _targetWay = way[wayCount];

        Vector3 dir = _targetWay.position - transform.position;
        Vector3 moveDir = dir.normalized;

        float movingSpeed;
        float wayDistance = Vector2.Distance
            (_targetWay.position, transform.position);

        Debug.Log(way[wayCount]);

        movingSpeed = wayDistance < 5f ? moveSpeed + 3.5f : moveSpeed;

        transform.position += moveDir * movingSpeed * Time.deltaTime;

        if (Vector3.Distance(transform.position, _targetWay.position) < 0.1f)
        {
            wayCount++;
            if (wayCount >= way.Length)
            {
                wayCount = 0;
            }
        }
    }

    public void FindClosestWayPoint()
    {
        for (int i = 0; i < way.Length; i++)
        {
            float distance = Vector2.Distance(transform.position, way[i].position);
            float minDistance = float.MaxValue;

            if (distance < minDistance)
            {
                minDistance = distance;
                wayCount = i;
            }
        }
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
