using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foothold2 : MonoBehaviour
{
    private Rigidbody2D rigid;
    [SerializeField] private bool isTime;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        isTime = true;
        if (other.gameObject.CompareTag("Player") && isTime == true)
        {
            StartCoroutine(FootholdCool());
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        isTime = false;
        if (other.gameObject.CompareTag("Player") && isTime == false)
        {
            rigid.bodyType = RigidbodyType2D.Static;
        }
    }

    IEnumerator FootholdCool()
    {
        yield return new WaitForSeconds(1.5f);
        rigid.bodyType = RigidbodyType2D.Dynamic;
    }
}
