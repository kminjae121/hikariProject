using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vine : MonoBehaviour
{
    [SerializeField] private PlayerMove player;

    public bool speedDown;
    private int previousSpeed;

    private void Awake()
    {
        previousSpeed = player._moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject. CompareTag("Player"))
        {
            speedDown = true;
            player._isVine = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        speedDown = false;
        player._isVine = false;
    }

    private void Update()
    {
        VineSpeed(player._moveSpeed);
    }

    private void VineSpeed(int currentMoveSpeed)
    {
        if (speedDown)
        {
            currentMoveSpeed = 1;
            player._moveSpeed = currentMoveSpeed;
            //player._isJump = false;
        }

        if (!speedDown)
        {
            player._moveSpeed = previousSpeed;
        }
    }
}
