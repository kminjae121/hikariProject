using System;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    private Camera mainCam;

    private void Awake()
    {
        mainCam = Camera.main;
    }

    private void Update()
    {
        GetMouseInput();
    }

    private void GetMouseInput()
    {
        Vector2 mouseXY = mainCam.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mouseXY;
    }
}