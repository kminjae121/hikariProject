using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BrightFoothold))]
public class LeafWall : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private BoxCollider2D _collideWall;

    private void Awake()
    {
        _collideWall = transform.Find("CollideWall").GetComponent<BoxCollider2D>();
        _spriteRenderer = transform.Find("Visual").GetComponent<SpriteRenderer>();
    }

    public void OnBrightFunction()
    {
        Debug.Log("¹à±â ¹ßµ¿");
        _spriteRenderer.enabled = false;
        _collideWall.enabled = false;
    }

    public void OffBrightFunction()
    {
        Debug.Log("¹à±â ¹ß¤¤¤·¤±¤¤µ¿");
        _spriteRenderer.enabled = true;
        _collideWall.enabled = true;
    }
}
