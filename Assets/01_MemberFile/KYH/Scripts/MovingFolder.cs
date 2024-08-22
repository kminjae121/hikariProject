using Cinemachine;
using System;
using UnityEngine;

public enum App
{
    Exit,
    WhatControll,
    File,
    Download,
    Game
}


public class MovingFolder : MonoBehaviour
{
    private Vector3 _mousePos;
    private bool _isHeld = false;

    public SettingButtonManager settingButton;

    //[SerializeField]
    //private GameObject settingObject;
    [SerializeField]
    private CinemachineVirtualCamera settingCamera;

    [SerializeField]
    private Vector2 boxSize;
    [SerializeField]
    private LayerMask whatIsPutStation;

    public LayerMask whatIsApp;
    public LayerMask whatIsPlayer;

    [SerializeField]
    private Transform usingApp;

    private static bool isSettingPanelChoose;
    private static Collider2D returnPos;

    public App thisObjectIsWhat;


    void Update()
    {
        if (!isSettingPanelChoose)
        {
            ClickFolder();
            if (_isHeld)
                HoldObject();
        }

    }


    private void ClickFolder()
    {
        _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _mousePos.z = 0;
        RaycastHit2D hit = Physics2D.Raycast(_mousePos, Vector2.zero, 0, whatIsApp);

        if (hit)
        {
            print(hit.collider.name);
            if (hit.collider == GetComponent<Collider2D>() && Input.GetMouseButtonDown(0))
            {
                settingButton.holdObject = hit.collider.gameObject;
                settingButton.holdObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                _isHeld = true;
            }
        }
    }

    private void HoldObject()
    {

        Collider2D player = null;
        Collider2D putStation = null;

        settingButton.holdObject.transform.position = Vector3.Lerp(settingButton.holdObject.transform.position, _mousePos, 10f * Time.deltaTime);
        putStation = Physics2D.OverlapBox(settingButton.holdObject.transform.position, boxSize, 0, whatIsPutStation); // 슬롯
        player = Physics2D.OverlapBox(settingButton.holdObject.transform.position, boxSize, 0, whatIsPlayer); // 플레이어

        if (Input.GetMouseButtonUp(0))
        {
            if (player)
            {
                settingCamera.Priority = 2;
                settingButton.holdObject.transform.SetParent(usingApp);
                settingButton.holdObject.transform.localPosition = Vector2.zero;
                settingButton.gameObject.SetActive(true);
                isSettingPanelChoose = true;
                returnPos = putStation;
                settingButton.currentAPP = thisObjectIsWhat;
                return;
            }
            else if ((putStation.gameObject.transform.childCount < 1 && putStation.CompareTag("Slot")))
            {
                settingButton.holdObject.transform.SetParent(putStation.transform);
            }
            EndHold();
        }

    }

    private void EndHold()
    {
        print("실행확인");
        _isHeld = false;
        settingButton.holdObject.transform.localPosition = Vector2.zero;
        settingButton.holdObject = null;
    }

    void OnDrawGizmos()
    {
        if (settingButton.holdObject == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(settingButton.holdObject.transform.position, boxSize);
        Gizmos.color = Color.white;
    }
    public void CancelButton()
    {
        isSettingPanelChoose = false;
        settingCamera.Priority = 0;
        settingButton.gameObject.SetActive(false);
        print(settingButton.holdObject);
        settingButton.holdObject.transform.SetParent(returnPos.transform);
        settingButton.holdObject.transform.localPosition = Vector2.zero;
        EndHold();
    }

}
