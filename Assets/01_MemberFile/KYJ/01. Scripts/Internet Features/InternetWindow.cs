using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InternetWindow : MonoBehaviour
{
    
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
