using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WindowObj : MonoBehaviour
{
    public static WindowObj Instance = null;

    public GameObject popUpChrome;

    private void Awake()
    {
        Instance = this;
    }
}
