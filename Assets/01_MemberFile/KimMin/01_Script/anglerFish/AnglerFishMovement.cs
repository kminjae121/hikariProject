using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnglerFishMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _chaseSpeed;
    [SerializeField] public float detectRadius;
    [SerializeField] private LayerMask _wallLayer;

    private Rigidbody2D _rigid;

    private RaycastHit2D _hit;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        _rigid.AddForce(Vector2.right * _moveSpeed * Time.deltaTime, ForceMode2D.Impulse);

        _hit = Physics2D.Raycast(transform.position, Vector2.right, 1f, _wallLayer);

        if (_hit)
        {
            ChangeDirection();
        }
    }

    private void ChangeDirection()
    {
        transform.localRotation = Quaternion.Euler(0, 180, 0);
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectRadius);

        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, detectRadius + 2);
    }
}
