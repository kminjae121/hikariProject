using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using System.Reflection;

public class SettingButtonManager : MonoBehaviour
{
    [SerializeField]
    private FolderManager folderManager;

    public GameObject holdObject;
    public App currentAPP;

    public GameObject gameAppScreen;
    public GameObject gameScriptManager;

    public void InvokeApp()
    {
        GetType().GetMethod($"{currentAPP}App", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).Invoke(this,null);
        //GetType().GetMethod("currnetApp").Invoke(this, new object[] {3, 4 });
    }



    private void ChromeApp()
    {
        folderManager.CancelButton();
        WindowObj.Instance.popUpChrome.SetActive(true);
    }

    private void ExitApp()
    {

    }

    private void YoutubeApp()
    {
        Process.Start("https://www.youtube.com/@jjangfish");
        folderManager.CancelButton();
    }

    private void WhatControllApp()
    {

    }
    private void PortPolioApp()
    {
        Process.Start("https://ggm.gondr.net/circle/info/7");
        folderManager.CancelButton();
    }
    private void PowerPointApp()
    {

    }
    private void GameApp()
    {
        gameAppScreen.SetActive(true);
        gameScriptManager.SetActive(true);
        folderManager.CancelButton();
    }

    public void GameAppExit()
    {
        gameAppScreen.SetActive(false);
        gameScriptManager.SetActive(false);
        folderManager.CancelButton();
    }
}
