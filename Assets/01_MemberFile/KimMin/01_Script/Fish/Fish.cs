using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Fish : MonoBehaviour
{
    public Rigidbody2D RigidCompo { get; private set; }
    public FishMovement MoveCompo { get; protected set; }
    public Animator AnimCompo { get; protected set; }
    public BrightPlants BrightPlant { get; protected set; }

    protected virtual void Awake()
    {
        RigidCompo = GetComponent<Rigidbody2D>();
        MoveCompo = GetComponent<FishMovement>();
        AnimCompo = transform.Find("Visual").GetComponent<Animator>();

        BrightPlant = new BrightPlants();
    }

    private bool IsFactingRight()
    {
        return Mathf.Approximately(transform.eulerAngles.y, 0);
    }

    public void SpriteFlip(Vector2 targetPosition)
    {
        bool isRight = IsFactingRight();
        if (targetPosition.x < transform.position.x && isRight)
        {
            transform.eulerAngles = new Vector3(0, -180f, 0);
        }
        else if (targetPosition.x > transform.position.x && !isRight)
        {
            transform.eulerAngles = Vector3.zero;
        }
    }
}
