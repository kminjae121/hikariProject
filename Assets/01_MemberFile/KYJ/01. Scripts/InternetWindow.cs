using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InternetWindow : PlayerMovement
{
    [SerializeField] private GameObject internetWindow;
    [SerializeField] private GameObject wifiWindow;


    void Awake()
    {
         wifiWindow.SetActive(false);

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
    }

    public void OnClickReadMore() // 자세히보기 버튼 누를 시
    {
        wifiWindow.SetActive(true);
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
