using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Vector3 moveDir;
    public Vector3 MoveDir
    {
        get
        {
            return moveDir;
        }
        set
        {
            moveDir = value;
        }
    }

    [SerializeField] private float speed = 3;
    [SerializeField] private float jumpForce = 5;
    [SerializeField] private LayerMask whatIsGround;

    private Rigidbody2D rigid;
    private SpriteRenderer sprite;

    [SerializeField] private Anchor anchor;

    public bool isLieDown; // 엎드리기 감지, 엎드린 상태에서 점프 막기 위함
    private bool isGround = false;
    private float Ray = 0.7f;
    private float x;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        PlayerMove();
        PlayerJump();
        CheackGround();

    }

    private void PlayerMove() // 플레이어 이동
    {
        x = Input.GetAxisRaw("Horizontal");
        moveDir = new Vector3(x * speed, rigid.velocity.y);
        rigid.velocity = moveDir;
        PlayerFlip();
    }

    private void PlayerFlip()
    {
        if (x < 0)
        {
            sprite.flipX = true;
            // transform.eulerAngles = new Vector3(0,-180f,0);
        }
        else if (x > 0)
        {
            sprite.flipX = false;
            // transform.eulerAngles = new Vector3(0, -0, 0);
        }
    }

    private void PlayerJump() // 플레이어 점프
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround && isLieDown == false)
        {
            rigid.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
            isGround = false;
        }
    }

    private void CheackGround() // 바닥 감지, 레이캐스트
    {
        isGround = Physics2D.Raycast(transform.position, Vector3.down, Ray, whatIsGround);
    }
}