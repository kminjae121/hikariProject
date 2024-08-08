using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Fish : MonoBehaviour
{

    public FishMovement moveCompo { get; protected set; }
    public Animator animCompo { get; protected set; }

    protected virtual void Awake()
    {
        moveCompo = GetComponent<FishMovement>();
        animCompo = GetComponent<Animator>();
    }
}
