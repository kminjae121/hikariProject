using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInput : PlayerMovement
{
    //private NewBehaviourScript window;
    [SerializeField] private bool isContactingPreview; // 미리보기 화면에 접촉 여부 bool
    [SerializeField] private GameObject SettingWindow;
    [SerializeField] private List<GameObject> button = new List<GameObject>();
    private bool isCoolTime;


    private void Awake()
    {
        //window = GameObject.Find("AppIcon").GetComponent<NewBehaviourScript>(); 
        for (int i = 0; i < button.Count; i++)
        {
            button[i].SetActive(false);
        }
        SettingWindow.SetActive(false);
    }

    private void Teleporting() // 플레이어가 미리보기 화면 속으로 이동
    {
        if (/*window.IsTriggerCursor == true && */isContactingPreview == true && Input.GetKeyDown(KeyCode.E)) // 윈도우에 커서가 닿고, 플레이어가 닿았으며 E키를 눌렀을 경우
        {
            SceneManager.LoadScene("PreviewScene"); // 미리보기 화면으로 씬 전환
        }
    }

    public void Buffering() // 와이파이 다운일 경우, 플레이어 움직임에 버퍼링
    {
        int i = Random.Range(0, 100);
        if (i < 50) // 50% 확률로
        {
            PlayerMove(0.1f); // 플레이어 이동 속도 감소
        }
        else
        {
            PlayerMove(4); // 유지
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PriviewWindow")) // 플레이어가 미리보기 화면에 닿았을 경우
        {
            isContactingPreview = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("PriviewWindow")) // 플레이어가 미리보기 화면에 닿았다가 떨어졌을 경우
        {
            isContactingPreview = false;
        }
    }
}
