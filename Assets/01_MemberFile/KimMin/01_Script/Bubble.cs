using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    [SerializeField] private float _detectRadius;
    [SerializeField] private float _speed;
    [SerializeField] private LayerMask _layerMask;

    private Rigidbody2D _rigid;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        CheckBubble();
    }

    private void AddingForce()
    {
        _rigid.AddForce(Vector2.up * _speed, ForceMode2D.Impulse);
    }

    private void CheckBubble()
    {
        Collider2D collider = Physics2D.OverlapCircle(transform.position,
            _detectRadius, _layerMask);

        if (collider)
        {
            AddingForce();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, _detectRadius);
    }
}
