using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Fish : MonoBehaviour
{
    public Rigidbody2D RigidCompo { get; private set; }
    public FishMovement MoveCompo { get; protected set; }
    public Animator AnimCompo { get; protected set; }

    protected virtual void Awake()
    {
        RigidCompo = GetComponent<Rigidbody2D>();
        MoveCompo = GetComponent<FishMovement>();
        AnimCompo = transform.Find("Visual").GetComponent<Animator>();
    }
}
