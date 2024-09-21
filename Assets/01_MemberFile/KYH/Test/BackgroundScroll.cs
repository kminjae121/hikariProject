using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    private SpriteRenderer _backsprite;
    private Vector2 backGroundScrollOffset = Vector2.zero;
    private void Awake()
    {
        _backsprite = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        BackgroundScrolling();
    }

    private void BackgroundScrolling()
    {
        backGroundScrollOffset.x += (_moveSpeed * Time.deltaTime);
        _backsprite.material.mainTextureOffset = backGroundScrollOffset;
    }
}

