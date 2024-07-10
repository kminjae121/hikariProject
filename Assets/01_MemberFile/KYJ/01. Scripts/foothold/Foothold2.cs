using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Foothold2 : MonoBehaviour
{
    private Rigidbody2D rigid;
    [SerializeField] private bool isTime;
    [SerializeField] private bool isBack;

    private float startPos;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        startPos = transform.position.y;
    }

    private void Update()
    {
        if (isTime == false)
        {
            StartCoroutine(ReturnFoothold());
        }
        else if (startPos == gameObject.transform.position.y)
        {
            StartCoroutine(FootholdCool());
        }
    }


    IEnumerator FootholdCool()
    {
        yield return new WaitForSeconds(1f);
        rigid.bodyType = RigidbodyType2D.Dynamic;
    }

    IEnumerator ReturnFoothold()
    {
        isTime = true;
        yield return new WaitForSeconds(5f);
        transform.DOMoveY(startPos, 3f);
        //transform.position = new Vector3(transform.position.x, startPos);
        isTime = false;
    }
}
