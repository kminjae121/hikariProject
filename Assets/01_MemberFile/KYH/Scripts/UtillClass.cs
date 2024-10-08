using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtillClass
{
    public static Camera _mainCamera;

    public static Vector3 GetMousePointerPosition()
    {
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;
        if (_mainCamera == null) _mainCamera = Camera.main;

        Vector2 mousePosition = _mainCamera.ScreenToWorldPoint(new Vector2(Mathf.Clamp(Input.mousePosition.x, 0, screenWidth), Mathf.Clamp(Input.mousePosition.y, 0, screenHeight)));
        return mousePosition;
    }
}
