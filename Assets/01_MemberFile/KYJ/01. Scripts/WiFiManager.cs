using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WiFiManager : MonoBehaviour
{
    public static WiFiManager instance = null;

    [SerializeField] private bool wifiOnOff = false;

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
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
