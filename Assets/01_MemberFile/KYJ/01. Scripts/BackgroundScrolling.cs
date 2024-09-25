using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundScrolling : MonoBehaviour
{
    [SerializeField] private float _scrolling = 0.5f;
    private SpriteRenderer spriteRenderer;


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Vector2 textureOffset = new Vector2(Time.time * _scrolling, 0);
        spriteRenderer.material.mainTextureOffset = textureOffset;
    }
}



