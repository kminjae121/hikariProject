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


<<<<<<< Updated upstream
    private void FixedUpdate()
    {
        PlayerMove(5f);
=======
    private void Update()
    {
        Teleporting();
        PlayerMove(4f);
>>>>>>> Stashed changes
    }


    protected virtual void PlayerMove(float speed) // 플레이어 이동
    {
        float x = Input.GetAxisRaw("Horizontal");
        Vector2 moveDir = new Vector2(x, 0);
        moveDir = moveDir.normalized;
        rigid.velocity = moveDir * speed;
    }
<<<<<<< Updated upstream
=======


    private void Teleporting() // 미리보기 화면으로 이동
    {
        if (priviewWindow.isContactingPreview == true && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene("PreviewScenes"); // 씬 전환
        }
    }


    public void Buffering() // 버퍼링 기능
    {
        int i = Random.Range(0, 100);
        if (i < 50 && !isCoolTime)
        {
            PlayerMove(0.1f);
        }
        else
        {
            PlayerMove(4);
        }
    }


    IEnumerator BufferingCool(float cooltime) // 버퍼링 쿨타임
    {
        isCoolTime = true;
        yield return new WaitForSeconds(cooltime);
        isCoolTime = false;
    }
>>>>>>> Stashed changes
}
