using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaWeedLadder : MonoBehaviour
{
    [SerializeField] private GameObject _target;
    [SerializeField] private float _power;

    private bool canLadder;

    private Rigidbody2D _rigid;

    private void Awake()
    {
        _rigid = _target.GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _rigid.gravityScale = 0f;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        float y = Input.GetAxisRaw("Vertical");

        canLadder = true;

        if (Mathf.Abs(y) > 0 && canLadder)
        {
            _rigid.velocity = new Vector2(_rigid.velocity.x, y * _power);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        canLadder = false;
        _rigid.gravityScale = 1f;
    }
}
