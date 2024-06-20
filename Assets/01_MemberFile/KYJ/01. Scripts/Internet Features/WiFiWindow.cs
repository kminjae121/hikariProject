using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WifiWindow : MonoBehaviour
{
    [SerializeField] private GameObject wifiWindow;
    [SerializeField] private TextMeshProUGUI text;

    private void Awake()
    {
        wifiWindow.SetActive(false);
    }


    public void OnClickBack() // 뒤로가기 버튼 누를 시
    {
        wifiWindow.SetActive(false);
    }

    public void OnClickConnection() // 연결 버튼을 누를 시
    {
        if (WiFiManager.instance.WifiOnOff == true) // 연결이 돼있을 때
        {
            WiFiManager.instance.WifiOnOff = false; // 연결 끊기
            text.text = "연결 안 됨";
        }

        else
        {
            WiFiManager.instance.WifiOnOff = true; // 연결하기
            text.text = "연결됨";
        }
    }
}
