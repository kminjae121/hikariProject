using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jellyfish : MonoBehaviour
{
    public float movePower = 1f;

    private Animator animator;
    private int movementFlag = 0;


    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        StartCoroutine("ChangeMovement");
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector3 moveVelocity = Vector3.zero;

        if (movementFlag == 1)
        {
            moveVelocity = Vector3.left;
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (movementFlag == 2)
        {
            moveVelocity = Vector3.right;
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (movementFlag == 3)
        {
            moveVelocity = new Vector3(1, 1, 0);
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (movementFlag == 4)
        {
            moveVelocity = new Vector3(-1, -1, 0);
            transform.localScale = new Vector3(1, 1, 1);
        }
        transform.position += moveVelocity * movePower * Time.deltaTime;
    }

    IEnumerator ChangeMovement()
    {
        movementFlag = UnityEngine.Random.Range(0, 5);
        if (movementFlag == 0)
        {
            animator.SetBool("isMoving", false);
        }
        yield return new WaitForSeconds(2f);

        StartCoroutine("ChangeMovement");
    }
}
