using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Network : PlayerMovement
{
    [SerializeField] private GameObject internetWindow;
    [SerializeField] private GameObject wifiWindow;

<<<<<<< Updated upstream
    [SerializeField] private List<GameObject> wifiButton = new List<GameObject>(); // 와이파이 버튼들
    private PlayerMovement playerMove;
    private PlayerInput playerInput;
=======
    private PlayerInput playerInput;
    private PlayerMovement playerMovement;
>>>>>>> Stashed changes


    void Awake()
    {
<<<<<<< Updated upstream
        internetWindow.SetActive(false); // 인터넷 화면 비활성화

        for (int i = 0; i < 2; i++)
        {
            wifiButton[i].SetActive(false); // 와이파이 버튼 비활성화
        }

        wifiWindow.SetActive(false);

        playerMove = GameObject.Find("Player").GetComponent<PlayerMovement>();
        playerInput = GameObject.Find("Player").GetComponent<PlayerInput>();
=======
        playerInput = FindObjectOfType<PlayerInput>();
        playerMovement = FindObjectOfType<PlayerMovement>();
        internetWindow.SetActive(false);
>>>>>>> Stashed changes
    }

    private void Update()
    {
        if (WiFiManager.instance.WifiOnOff == false)
        {
            playerInput.Buffering();
        }
        else
        {
            playerMovement.PlayerMove(4f);
        }
    }

    public void OnClickBack() // 뒤로가기 버튼 누를 시
    {
        internetWindow.SetActive(false); 

        for (int i = 0; i < 2; i++)
        {
            wifiButton[i].SetActive(false);
        }
    }

    public void OnClickInternet() // 인터넷 버튼 누를 시
    {
        internetWindow.SetActive(true);

        for (int i = 0; i < 2; i++)
        {
            wifiButton[i].SetActive(true);
        }
    }

    public void OnClickWifi() // 와이파이 버튼 누를 시
    {
        if (WiFiManager.instance.WifiOnOff == false)
        {
            WiFiManager.instance.WifiOnOff = true;
        }
        else
        {
            WiFiManager.instance.WifiOnOff = false;
        }
    }
}
