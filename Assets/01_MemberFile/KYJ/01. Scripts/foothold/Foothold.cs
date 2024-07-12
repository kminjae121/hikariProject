using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foothold : MonoBehaviour
{
    private Rigidbody2D rigid;
    private bool isCool;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(FootholdCool());
        }
    }

    IEnumerator FootholdCool()
    {
        yield return new WaitForSeconds(3f);
        rigid.bodyType = RigidbodyType2D.Dynamic;
    }
}
