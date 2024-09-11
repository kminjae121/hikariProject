using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtillClass
{
    public static Camera _mainCamera;

    public static Vector3 GetMousePointerPosition()
    {
        if (_mainCamera == null) _mainCamera = Camera.main;

        Vector2 mousePosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        return mousePosition;
    }
}
