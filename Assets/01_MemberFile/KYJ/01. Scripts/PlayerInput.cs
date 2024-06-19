using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInput : PlayerMovement
{
    [SerializeField] private GameObject SettingWindow;
    [SerializeField] private List<GameObject> button = new List<GameObject>();
    private PriviewWindow priviewWindow;


    private void Awake()
    {
        priviewWindow = GameObject.Find("PriviewWindow").GetComponent<PriviewWindow>();

        for (int i = 0; i < button.Count; i++)
        {
            button[i].SetActive(false);
        }
        SettingWindow.SetActive(false);
    }

    private void Update()
    {
        Teleporting();
    }

    private void Teleporting() // 플레이어가 미리보기 화면 속으로 이동
    {
        if (priviewWindow.isContactingPreview == true && Input.GetKeyDown(KeyCode.E)) // 윈도우에 커서가 닿고, 플레이어가 닿았으며 E키를 눌렀을 경우
        {
            print("접촉");
            SceneManager.LoadScene("PreviewScenes"); // 미리보기 화면으로 씬 전환
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

    
}
