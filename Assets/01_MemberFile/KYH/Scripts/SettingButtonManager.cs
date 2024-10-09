using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using System.Reflection;
using System;

public class SettingButtonManager : MonoBehaviour
{
    [SerializeField]
    private FolderManager folderManager;

    public GameObject holdObject;
    public App currentAPP;

    public GameObject gameAppScreen;
    public GameObject gameScriptManager;

    public GameObject quitPopUp;

    [SerializeField]
    private GameObject descriptionPanel;

    [SerializeField]
    private GameObject howControll;

    public void InvokeApp()
    {
        descriptionPanel.SetActive(false);
        GetType().GetMethod($"{currentAPP}App", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).Invoke(this,null);
        //GetType().GetMethod("currnetApp").Invoke(this, new object[] {3, 4 });
    }



    private void ChromeApp()
    {
        QuestPopupUI.Instance.QuestTxt();
        folderManager.CancelButton();
        WindowObj.Instance.popUpChrome.SetActive(true);
    }

    private void ExitApp()
    {
        folderManager.CancelButton();
        quitPopUp.SetActive(true);
    }

    private void YoutubeApp()
    {
        Process.Start("https://youtu.be/QmcnyXTKrKg");
        folderManager.CancelButton();
    }

    private void WeatherApp()
    {
        Process.Start("msnweather://forecast?la=[latitude]&lo=[longitude]");
        folderManager.CancelButton();
    }

    private void HowControllApp()
    {
        howControll.SetActive(true);
        folderManager.CancelButton();
        //string strPath = Application.dataPath + "/GameControll.png";

        //print(strPath);

        //Process.Start($"ms-photos:viewer?fileName={strPath}");
        //Process.Start("notepad.exe");
    }
    private void PortPolioApp()
    {
        Process.Start("https://ggm.gondr.net/circle/info/7");
        folderManager.CancelButton();
    }
    private void PowerPointApp()
    {
        folderManager.CancelButton();
        WindowObj.Instance.popUpPowerPoint.SetActive(true);
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
    }
}
