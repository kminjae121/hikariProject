using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vine : MonoBehaviour
{
    public bool speedDown;
    [SerializeField] private PlayerMove player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject. CompareTag("Player"))
        {
            speedDown = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        speedDown = false;
    }

    private void Update()
    {
        VineSpeed(player._moveSpeed);
    }

    private void VineSpeed(int _moveSpeed)
    {
        if (speedDown)
        {
            _moveSpeed -= 3;
        }
        else if(!speedDown)
        {
           _moveSpeed = player._moveSpeed;
        }
        player._moveSpeed = _moveSpeed;
    }
}
