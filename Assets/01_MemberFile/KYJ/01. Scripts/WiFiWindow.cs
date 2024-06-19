using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WifiWindow : MonoBehaviour
{
    [SerializeField] private GameObject wifiWindow;
    [SerializeField] private TextMeshProUGUI text;
    private InternetWindow internetWindow;

    private void Awake()
    {
        internetWindow = FindObjectOfType<InternetWindow>();
        wifiWindow.SetActive(false);
    }

    public void OnClickBack()
    {
        wifiWindow.SetActive(false);
    }

    public void OnClickConnection()
    {
        if (WiFiManager.instance.WifiOnOff == true)
        {
            WiFiManager.instance.WifiOnOff = false;
            text.text = "¿¬°áµÊ";
        }

        else
        {
            WiFiManager.instance.WifiOnOff = true;
            text.text = "¿¬°á ¾È µÊ";
        }
    }
}
