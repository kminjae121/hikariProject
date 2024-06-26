using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FirewallManger : Monosingleton<FirewallManger>
{
    private bool isCool;
    [SerializeField] private bool virusOnOff;
    [SerializeField] private bool firewallOnOff; // 와이파이 발동 여부
    public bool FirewallOnOff
    {
        get
        {
            return firewallOnOff;
        }
        set
        {
            firewallOnOff = value;
        }
    }

    [SerializeField] private TextMeshProUGUI text; // 와이파이 연결 여부 텍스트

    private WiFiManager wifiManager;


    private void Awake()
    {
        wifiManager = GameObject.Find("WiFiManager").GetComponent<WiFiManager>();
    }


    private void Update()
    {
        VirusOnOff();
        StartCoroutine(WifiCool());
    }


    private void VirusOnOff() // 바이러스 여부 방화벽 온오프
    {
        if (virusOnOff == true)
        {
            firewallOnOff = false;
        }
        else
        {
            firewallOnOff = true;
        }
    }

    private IEnumerator WifiCool() // 와이파이 랜덤 연결 쿨타임
    {
        if (firewallOnOff == false && isCool == false) // 방화벽 연결 끊겼을 때
        {
            isCool = true;
            int rand1 = Random.Range(3, 10);
            yield return new WaitForSeconds(rand1);
            wifiManager.RandomOnOff(0f, 50f); // 와이파이 다운 확률 업
            print("확률 업!");
            isCool = false;
        }
        else if (firewallOnOff == true && isCool == false)
        {
            isCool = true;
            int rand = Random.Range(3, 10);
            yield return new WaitForSeconds(rand);
            wifiManager.RandomOnOff(0f, 20f); // 확률 그대로
            print("확률 보존!");
            isCool = false;
        }
    }
}
