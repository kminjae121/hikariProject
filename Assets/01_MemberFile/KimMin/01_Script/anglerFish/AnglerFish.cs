using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnglerFish : AnglerFishMovement
{
    public float moveSpeed;
    public float chaseSpeed;
    public float detectRadius;
    public LayerMask wallLayer;

    public Transform targetTrm;

    private void FixedUpdate()
    {
        Move(moveSpeed, wallLayer);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectRadius);

        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, detectRadius + 2);
    }
}
