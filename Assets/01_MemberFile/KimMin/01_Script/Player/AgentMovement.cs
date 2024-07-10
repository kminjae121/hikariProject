using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentMovement : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] private Transform _groundCheckerTrm;

    [Header("Settings")]
    public float moveSpeed = 5f;
    public float jumpPower = 7f;

    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private Vector2 _groundCheckerSize;

    public Rigidbody2D rigid { get; private set; }

    public NotifyValue<bool> isGround = new NotifyValue<bool>();

    protected float _xMove;

    public void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    public void JumpTo(Vector2 force)
    {
        SetMovement(force.x);
        rigid.AddForce(force, ForceMode2D.Impulse);
    }

    public void SetMovement(float xMove)
    {
        _xMove = xMove;
    }

    public void Jump(float multiplier = 1f)
    {
        rigid.velocity = Vector2.zero;
        rigid.AddForce(Vector2.up * jumpPower * multiplier, ForceMode2D.Impulse);
    }

    private void FixedUpdate()
    {
        CheckGrounded();
        ApplyXMovement();
    }

    private void ApplyXMovement()
    {
        rigid.velocity = new Vector2(_xMove * moveSpeed, rigid.velocity.y);
    }

    public void CheckGrounded()
    {
        Collider2D collider = Physics2D.OverlapBox(_groundCheckerTrm.position, _groundCheckerSize, 0, _groundLayer);
        isGround.Value = collider != null;
    }
}
