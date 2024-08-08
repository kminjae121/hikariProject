using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FishSetting : Fish
{
    public int wayCount;
    public float detectRadius;
    public float moveSpeed;
    public Transform[] way;
    public Vector3 moveDir;

    protected override void Awake()
    {
        base.Awake();
    }

    public void Move()
    {
        Transform targetWay = way[wayCount];
        Vector3 dir = targetWay.position - transform.position;

        Vector3 moveDir = dir.normalized;

        transform.position += moveDir * moveSpeed * Time.deltaTime;

        if (Vector3.Distance(transform.position, targetWay.position) < 0.1f)
        {
            wayCount++;
            if (wayCount >= way.Length)
            {
                wayCount = 0;
            }
        }
        
    }
}
