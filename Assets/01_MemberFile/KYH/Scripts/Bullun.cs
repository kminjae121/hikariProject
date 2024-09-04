using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullun : MonoBehaviour
{
    private Rigidbody2D rigid;
    private bool isTrigger=false;

    [SerializeField]
    private float moveSpeed;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            SetMove(Vector2.up);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            print("엑시트 작동중");
            SetMove(Vector2.zero);
        }
    }

    private void SetMove(Vector2 moveDir)
    {
            print("ㅊ ㅇ둘");
        rigid.velocity = moveDir * moveSpeed;
    }
}
