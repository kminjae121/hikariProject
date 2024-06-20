using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WiFiManager : MonoBehaviour
{
    public static WiFiManager instance = null;

    [SerializeField] private bool wifiOnOff; // 와이파이 발동 여부

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
    }
}
