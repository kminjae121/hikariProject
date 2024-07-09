using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Foothold1 : MonoBehaviour
{
    private Rigidbody2D rigid;
    [SerializeField] private bool isTime;

    float i = 3f;
    Vector3 moveDir = new Vector3(0, 10f, 0);

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player") && isTime == false)
        {
            StartCoroutine(FootholdCool());
        }
        StartCoroutine(ReturnFoothold());
            transform.DOMoveY(20, i);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {

    }

    IEnumerator FootholdCool()
    {
        yield return new WaitForSeconds(0.5f);
        rigid.bodyType = RigidbodyType2D.Dynamic;
    }
    
    IEnumerator ReturnFoothold()
    {
        yield return new WaitForSeconds(3f);
    }
}
