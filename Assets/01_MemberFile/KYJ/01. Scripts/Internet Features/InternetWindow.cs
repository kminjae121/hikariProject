using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InternetWindow : MonoBehaviour
{
    [SerializeField] private GameObject internetWindow;
    [SerializeField] private GameObject wifiWindow;



    void Awake()
    {
        internetWindow.SetActive(false);
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
        if (WiFiManager.instance.WifiOnOff == false) // 와이파이 끊겼을 때
        {
            WiFiManager.instance.WifiOnOff = true; // 와이파이 연결하기
        }
        else
        {
            WiFiManager.instance.WifiOnOff = false;
        }
    }
}
