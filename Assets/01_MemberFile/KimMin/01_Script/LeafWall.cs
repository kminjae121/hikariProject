using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BrightFoothold))]
public class LeafWall : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private BoxCollider2D _collideWall;
    private Animator _animator;

    private void Awake()
    {
        _collideWall = transform.Find("CollideWall").GetComponent<BoxCollider2D>();
        _spriteRenderer = transform.Find("Visual").GetComponent<SpriteRenderer>();
        _animator = transform.Find("Visual").GetComponent<Animator>();
    }

    public void OnBrightFunction()
    {
        Debug.Log("¹à±â ¹ßµ¿");
        _animator.SetBool("Generate", true);
        _collideWall.enabled = false;
    }

    public void OffBrightFunction()
    {
        Debug.Log("¹à±â ¹ß¤¤¤·¤±¤¤µ¿");
        _animator.SetBool("Generate", false);
        _collideWall.enabled = true;
    }
}
