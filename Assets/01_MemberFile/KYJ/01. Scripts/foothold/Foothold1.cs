using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foothold1 : MonoBehaviour
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

    private void OnCollisionExit2D(Collision2D collision)
    {
        isTime = false;
    }

    IEnumerator FootholdCool()
    {
        yield return new WaitForSeconds(0.5f);
        rigid.bodyType = RigidbodyType2D.Dynamic;
    }
}
