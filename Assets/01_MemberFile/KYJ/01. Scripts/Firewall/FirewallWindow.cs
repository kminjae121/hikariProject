using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FirewallWindow : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text; // 와이파이 연결 여부 텍스트


    public void FirewallConnection() // 방화벽 연결 시 텍스트 변경
    {
        if (FirewallManger.Instance.FirewallOnOff == true) // 연결이 돼있을 때
        {
            FirewallManger.Instance.FirewallOnOff = false;
            text.text = "연결 안 됨";
        }

        else
        {
            FirewallManger.Instance.FirewallOnOff = true;
            text.text = "연결됨";
        }
    }
}
