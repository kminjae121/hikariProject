using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Foothold1 : MonoBehaviour
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
        if (isBack == true && isTime == false)
        {
            StartCoroutine(ReturnFoothold());
        }
        else if (startPos == gameObject.transform.position.y)
        {
            isBack = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player") && isBack == false)
        {
            StartCoroutine(FootholdCool());
            isBack = true;
        }
    }

    IEnumerator FootholdCool()
    {
        yield return new WaitForSeconds(0.5f);
        rigid.bodyType = RigidbodyType2D.Dynamic;
    }
    
    IEnumerator ReturnFoothold()
    {
        isTime = true;
        yield return new WaitForSeconds(5f);
        rigid.bodyType = RigidbodyType2D.Static;
        transform.DOMoveY(startPos, 3f);
        //transform.position = new Vector3(transform.position.x, startPos);
        isTime = false;
    }
}
