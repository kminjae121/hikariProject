using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Fish : MonoBehaviour
{

    public FishMovement MoveCompo { get; protected set; }
    public Animator AnimCompo { get; protected set; }

    protected virtual void Awake()
    {
        MoveCompo = GetComponent<FishMovement>();
        AnimCompo = transform.Find("Visual").GetComponent<Animator>();
    }
}
