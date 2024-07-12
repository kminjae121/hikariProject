using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Foothold1 : Foothold
{
    protected override void Awake()
    {
        base.Awake();
        _rigid = GetComponent<Rigidbody2D>();
        startPos = transform.position.y;
    }

    private void Update()
    {
        //base.MoveFoothold(5f, 3f);
    }   

    //private void OnCollisionEnter2D(Collision2D other)
    //{
    //    if (other.gameObject.CompareTag("Player") && isBack == false)
    //    {
    //        StartCoroutine(FootholdCool(3f));
    //        isBack = true;
    //    }
    //}

    //protected override IEnumerator ReturnFoothold(float coolTime, float dgTime)
    //{
    //    return base.ReturnFoothold(coolTime, dgTime);
    //}

    //protected override IEnumerator FootholdCool(float coolTime)
    //{
    //    return base.FootholdCool(coolTime);
    //}
}
