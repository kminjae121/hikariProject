using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swallow : MonoBehaviour
{
    private float _speed = 15f;

    private void AddingForce(Rigidbody2D rigid)
    {
        rigid.AddForce(Vector2.up * -_speed, ForceMode2D.Force);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Rigidbody2D rigid = collision.GetComponent<Rigidbody2D>();
            AddingForce(rigid);
        }
    }
}
