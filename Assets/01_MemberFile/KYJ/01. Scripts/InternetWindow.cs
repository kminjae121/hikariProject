using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InternetWindow : PlayerMovement
{
    [SerializeField] private GameObject internetWindow;
    [SerializeField] private GameObject wifiWindow;

    private PlayerInput playerInput;
    private PlayerMovement playerMovement;


    void Awake()
    {
        playerInput = FindObjectOfType<PlayerInput>();
        playerMovement = FindObjectOfType<PlayerMovement>();
        internetWindow.SetActive(false);
    }

    private void Update()
    {
        if (WiFiManager.instance.WifiOnOff == false)
        {
            playerInput.Buffering();
        }
        else
        {
            playerMovement.PlayerMove(4f);
        }
    }

    public void OnClickBack() // 뒤로가기 버튼 누를 시
    {
        internetWindow.SetActive(false); 
    }

    public void OnClickReadMore() // 자세히보기 버튼 누를 시
    {
        wifiWindow.SetActive(true);
    }

    
    public void OnClickWifi() // 와이파이 버튼 누를 시
    {
        if (WiFiManager.instance.WifiOnOff == false)
        {
            WiFiManager.instance.WifiOnOff = true;
        }
        else
        {
            WiFiManager.instance.WifiOnOff = false;
        }
    }
}
