using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [Header ("Setting")]
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private int _moveSpeed;
    [SerializeField] private int _jumpSpeed;
    [SerializeField] private Transform _groundChecker;
    [SerializeField] private Vector2 _boxSize;
    [SerializeField] private LayerMask _whatIsGround;

    public bool _isJump { get; set; }
    public Rigidbody2D _rigid { get; set; }
    private Vector2 _xmove;

    private void Awake()
    {
        _isJump = true;
        _inputReader.JumpKeyEvent += Jump;
        _rigid = GetComponent<Rigidbody2D>();
    }

    private void OnDestroy()
    {
        _inputReader.JumpKeyEvent -= Jump;
    }

    private void Update()
    {
        _isJump = Physics2D.OverlapBox(_groundChecker.position, _boxSize, 0, _whatIsGround);
        SetMove(_inputReader.Movement.x);
    }

    private void SetMove(float Xmove)
    {
        _xmove.x = Xmove;
    }

    private void Jump()
    {

        if (_isJump == true)
        {
            _rigid.velocity = Vector2.zero;

            _rigid.AddForce(Vector2.up * _jumpSpeed * 1, ForceMode2D.Impulse);
        }
    }


    private void FixedUpdate()
    {
        _rigid.velocity = new Vector2(_xmove.x * _moveSpeed, _rigid.velocity.y);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(_groundChecker.position, _boxSize);
        Gizmos.color = Color.white;
    }
}
