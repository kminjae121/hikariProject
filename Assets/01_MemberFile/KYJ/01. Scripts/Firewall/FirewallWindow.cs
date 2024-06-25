using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FirewallWindow : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text; // 와이파이 연결 여부 텍스트

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void FirewallConnection()
    {
        if (FirewallManger.instance.FirewallOnOff == true) // 연결이 돼있을 때
        {
            WiFiManager.instance.WifiOnOff = false; // 연결 끊기
            text.text = "연결 안 됨";
        }

        else
        {
            FirewallManger.instance.FirewallOnOff = true; // 연결하기
            text.text = "연결됨";
        }
    }
}
