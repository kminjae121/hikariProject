using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FirewallManger : MonoBehaviour
{
    public static FirewallManger instance = null;

    [SerializeField] private bool firewallOnOff; // 와이파이 발동 여부
    [SerializeField] private TextMeshProUGUI text; // 와이파이 연결 여부 텍스트

    private PlayerMovement playerMovement;

    private bool isCool = true; // 쿨타임 제어


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

    private void Awake()
    {
        if (instance == null) // 싱글톤입니다
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }


    private void Update()
    {
        //if (isCool == true)
        //    StartCoroutine(WifiCool());

        FirewallConnection();


        if (firewallOnOff == false) // 방화벽 연결 끊겼을 때
        {

        }
        else
        {

        }
    }


    private void RandomOnOff() // 바이러스 여부 방화벽 온오프
    {
        int rand = Random.Range(0, 100);

        if (rand < 30)
        {
            firewallOnOff = false;
        }
        else
        {
            firewallOnOff = true;
        }
    }

    private void FirewallConnection() // 방화벽 연결 시 텍스트 변경
    {
        if (firewallOnOff == true) // 연결이 돼있을 때
        {
            text.text = "연결됨";
        }

        else
        {
            text.text = "연결 안 됨";
        }
    }

    //private IEnumerator WifiCool() // 와이파이 랜덤 연결 쿨타임
    //{
    //    isCool = false;
    //    int rand = Random.Range(3, 10);
    //    yield return new WaitForSeconds(rand);
    //    RandomOnOff();
    //    print("실행");
    //    isCool = true;
    //}
}
