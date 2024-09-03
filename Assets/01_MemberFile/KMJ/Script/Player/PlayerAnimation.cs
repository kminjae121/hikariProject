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
    [field: SerializeField] public bool isFlower { get; set; }
    

    private void Awake()
    { 
        _spriteCompo = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        ChangeAnimation();
        FlowerAnimation();
        RunAnimation();
        PlayerFilpX();
        JumpAniamtion();
        SwimAnimation();
    }


    private void ChangeAnimation()
    {
        if(isFlower)
        {
            _animator.SetLayerWeight(0, 1f);
            _animator.SetLayerWeight(1, 1f);
        }
        else
        {
            _animator.SetLayerWeight(0, 1f);
            _animator.SetLayerWeight(1, 0f);
        }
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
        if (_inputReader.Movement.x != 0 && isFlower == false)
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
        if(_playerMove._isJump == false && isFlower == false)
        {
            _animator.SetBool("Jump", true);
        }
        else
        {
            _animator.SetBool("Jump", false);
        }    
    }


    private void FlowerAnimation()
    {
        if (_inputReader.Movement.x != 0)
        {
            _animator.SetBool("FlowerWalk", true);
        }
        else
        {
            _animator.SetBool("FlowerWalk", false);
        }
    }

    private void SwimAnimation()
    {
        if(_playerMove.isSwimming == true)
        {
            _spriteCompo.flipX = false;
            _animator.SetLayerWeight(0, 0f);
            _animator.SetLayerWeight(2, 1f);
        }
        else
        {
            _animator.SetLayerWeight(0, 1f);
            _animator.SetLayerWeight(2, 0f);
        }
    }
}
