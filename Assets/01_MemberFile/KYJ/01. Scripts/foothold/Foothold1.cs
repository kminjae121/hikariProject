using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Foothold1 : Foothold
{
    protected override void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
        startPos = transform.position.y;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("ddd");
            StartCoroutine(DownMoveFoothold(0.5f));
            StartCoroutine(UpMoveFoothold(4f));
        }
    }

    protected override IEnumerator UpMoveFoothold(float stopTime)
    {
        return base.UpMoveFoothold(stopTime);
    }

    protected override IEnumerator DownMoveFoothold(float stopTime)
    {
        return base.DownMoveFoothold(stopTime);
    }
}
