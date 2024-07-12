using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public abstract class Foothold : MonoBehaviour
{
    protected Rigidbody2D _rigid;

    protected bool isBack;

    protected float startPos;

    protected virtual void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();

        startPos = transform.position.y;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Water"))
        {
            isBack = true;
        }
    }

    protected virtual IEnumerator MoveFoothold(float stopTime) 
    {
        if (transform.position.y == startPos)
        {
            isBack = false;
            yield return new WaitForSeconds(stopTime);
            _rigid.bodyType = RigidbodyType2D.Dynamic;
        }
        else if (transform.position.y != startPos && !isBack)
        {
            yield return new WaitForSeconds(stopTime); 
            _rigid.bodyType = RigidbodyType2D.Static; 
            transform.DOMoveY(startPos, 3f); 
        }
    }
}
