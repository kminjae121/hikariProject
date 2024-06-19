using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInput : PlayerMovement
{
    [SerializeField] private GameObject SettingWindow;

    private void Awake()
    {
        SettingWindow.SetActive(false);
    }


    private void Update()
    {
        SettingWindowOn();
    }


    private void SettingWindowOn() // esc 키를 누를 시
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SettingWindow.SetActive(true); // 설정창 활성화
        }
    }
}
