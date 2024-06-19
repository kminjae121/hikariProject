using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Network : PlayerMovement
{
    [SerializeField] private GameObject internetWindow;
    [SerializeField] private GameObject wifiWindow;

    [SerializeField] private List<GameObject> wifiButton = new List<GameObject>(); // 와이파이 버튼들
    private PlayerMovement playerMove;
    private PlayerInput playerInput;


    void Awake()
    {
        internetWindow.SetActive(false); // 인터넷 화면 비활성화

        for (int i = 0; i < 2; i++)
        {
            wifiButton[i].SetActive(false); // 와이파이 버튼 비활성화
        }

        wifiWindow.SetActive(false);

        playerMove = GameObject.Find("Player").GetComponent<PlayerMovement>();
        playerInput = GameObject.Find("Player").GetComponent<PlayerInput>();
    }

    private void Update()
    {
        //if (GameManager.instance.WifiOnOff == false)
        //{
        //    playerInput.Buffering();
        //}
        //else
        //{
        //    playerMove.PlayerMove(4f);
        //}
    }

    public void OnClickBack() // 뒤로가기 버튼 누를 시
    {
        internetWindow.SetActive(false); 

        for (int i = 0; i < 2; i++)
        {
            wifiButton[i].SetActive(false);
        }
    }

    public void OnClickInternet() // 인터넷 버튼 누를 시
    {
        internetWindow.SetActive(true);

        for (int i = 0; i < 2; i++)
        {
            wifiButton[i].SetActive(true);
        }
    }

    public void OnClickWifi() // 와이파이 버튼 누를 시
    {
        //if (GameManager.instance.WifiOnOff == false)
        //{
        //    GameManager.instance.WifiOnOff = true;
        //}
        //else
        //{
        //    GameManager.instance.WifiOnOff = false;
        //}
    }
}
