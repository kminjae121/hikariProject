using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingButtonManager : MonoBehaviour
{
    public GameObject holdObject;

    public App currentAPP;

    public void InvokeApp()
    {
        GetType().GetMethod($"{currentAPP}App").Invoke(this, null);
        //GetType().GetMethod("currnetApp").Invoke(this, new object[] {3, 4 });
    }

    private void ExitApp()
    {

    }

    private void SteamApp()
    {

    }

    private void WhatControllApp()
    {

    }
    private void FileApp()
    {

    }
    private void DownloadApp()
    {

    }
    private void GameApp()
    {

    }
}
