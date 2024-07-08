using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InternetWindow : MonoBehaviour
{
    private void Awake()
    {
        gameObject.SetActive(false); // 처음에 인터넷 화면 비활성화
    }

    public void OnClickBack() // 뒤로가기 버튼 누를 시
    {
        gameObject.SetActive(false); // 인터넷 화면 닫기
    }

    public void OnClickWifi() // 와이파이 버튼 누를 시
    {
        if(WiFiManager.Instance.WifiOnOff == false) // 와이파이 끊겼을 때
        {
            WiFiManager.Instance.WifiOnOff = true; // 와이파이 연결하기
        }
        else
        {
            WiFiManager.Instance.WifiOnOff = false;
        }
    }
}
