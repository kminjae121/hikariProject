using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using System.Reflection;

public class SettingButtonManager : MonoBehaviour
{
    public GameObject holdObject;

    public App currentAPP;

    public void InvokeApp()
    {
        GetType().GetMethod($"{currentAPP}App", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).Invoke(this,null);
        //GetType().GetMethod("currnetApp").Invoke(this, new object[] {3, 4 });
    }

    private void ExitApp()
    {

    }

    private void YoutubeApp()
    {
        Process.Start("https://www.youtube.com/@jjangfish");
    }

    private void WhatControllApp()
    {

    }
    private void PortPolioApp()
    {
        Process.Start("https://ggm.gondr.net/circle/info/7");
    }
    private void DownloadApp()
    {

    }
    private void GameApp()
    {

    }
}
