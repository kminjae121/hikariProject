using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private PlayerMove _playerMove;
    [SerializeField] private InputReader _inputReader;
    private Animator _animator;
    private SpriteRenderer _spriteCompo;
    

    private void Awake()
    {
        _spriteCompo = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        RunAnimation();
        PlayerFilpX();
        JumpAniamtion();
    }

    private void PlayerFilpX()
    {
        if (_inputReader.Movement.x < 0)
        {
            _spriteCompo.flipX = true;
        }
        else if (_inputReader.Movement.x == 0 && _spriteCompo.flipX == true)
        {
            _spriteCompo.flipX = true;
        }
        else
        {
            _spriteCompo.flipX = false;
        }
    }
    private void RunAnimation()
    {
        if (_inputReader.Movement.x != 0)
        {
            _animator.SetBool("Run", true);
        }
        else
        {
            _animator.SetBool("Run", false);
        }
    }

    private void JumpAniamtion()
    {
        if(_playerMove._isJump == false)
        {
            _animator.SetBool("Jump", true);
        }
        else
        {
            _animator.SetBool("Jump", false);
        }    
    }
}
