using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour
{
    private PriviewWindow priviewWindow;
    private Rigidbody2D rigid;

    private bool isCoolTime;


    private void Awake()
    {
        priviewWindow = GameObject.Find("PriviewWindow").GetComponent<PriviewWindow>();
        rigid = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        Teleporting();
        PlayerMove(4f);
    }
    

    public void PlayerMove(float speed) // 플레이어 이동
    {
        float x = Input.GetAxisRaw("Horizontal");
        Vector2 moveDir = new Vector2(x, 0);
        moveDir = moveDir.normalized;
        rigid.velocity = moveDir * speed;
    }


    private void Teleporting() // 미리보기 화면으로 이동
    {
        if (priviewWindow.IsContactingPreview == true && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene("PreviewScenes"); // 미리보기 화면 씬으로 전환
        }
    }


    public void Buffering() // 버퍼링 기능
    {
        int i = Random.Range(0, 100);
        if (i < 50 && !isCoolTime) // 50퍼 확률로
        {
            PlayerMove(0.1f); // 버퍼링
        }
        else
        {
            PlayerMove(4f);
        }
    }
}
