using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region 컴포넌트
    private Rigidbody2D rigid;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    #endregion


    private void FixedUpdate()
    {
        PlayerMove(5f);
    }


    protected virtual void PlayerMove(float speed) // 플레이어 이동
    {
        float x = Input.GetAxisRaw("Horizontal");
        Vector3 moveDir = new Vector3(x * speed, rigid.velocity.y);
        rigid.velocity = moveDir;
    }
}
