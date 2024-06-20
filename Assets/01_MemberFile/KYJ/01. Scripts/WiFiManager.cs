using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WiFiManager : MonoBehaviour
{
    public static WiFiManager instance = null;

    [SerializeField] private bool wifiOnOff; // 와이파이 발동 여부
    [SerializeField] private TextMeshProUGUI text; // 와이파이 연결 여부 텍스트

    private PlayerMovement playerMovement;

    private bool isCool = true; // 쿨타임 제어


    public bool WifiOnOff
    {
        get
        {
            return wifiOnOff;
        }
        set
        {
            wifiOnOff = value;
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

        playerMovement = FindObjectOfType<PlayerMovement>();
    }


    private void Update()
    {
        if(isCool == true)
        StartCoroutine(WifiCool());

        WifiConnection();


        if (WifiOnOff == false) // 와이파이 연결 끊겼을 때
        {
            playerMovement.Buffering(); // 버퍼링 기능 
        }
        else
        {
            playerMovement.PlayerMove(4f); // 아니면 그냥 이동 기능
        }
    }


    private void RandomOnOff() // 랜덤으로 와이파이 온오프
    {
        int rand = Random.Range(0, 100);

        if (rand < 30)
        {
            wifiOnOff = false;
        }
        else
        {
            wifiOnOff = true;
        }
    }

    private void WifiConnection() // 와이파이 연결 시 텍스트 변경
    {
        if (WifiOnOff == true) // 연결이 돼있을 때
        {
            text.text = "연결됨";
        }

        else
        {
            text.text = "연결 안 됨";
        }
    }

    private IEnumerator WifiCool() // 와이파이 랜덤 연결 쿨타임
    {
        isCool = false;
        int rand = Random.Range(3, 10);
        yield return new WaitForSeconds(rand);
        RandomOnOff();
        print("실행");
        isCool = true;
    }
}
