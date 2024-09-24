using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    private Camera mainCam;
    [SerializeField]
    private float moveSpeed = 0.15f;

    private Vector2 initialPosition; // 배경의 초기 위치를 저장할 변수

    private void Awake()
    {
        mainCam = mainCam == null ? Camera.main : mainCam;
        initialPosition = transform.position; // 배경의 초기 위치 저장
    }

    private void FixedUpdate()
    {
        // 배경이 카메라의 움직임에 맞춰 초기 위치를 기준으로 이동하게 함
        transform.position = new Vector2(initialPosition.x + mainCam.transform.position.x * moveSpeed, initialPosition.y);
    }
}

