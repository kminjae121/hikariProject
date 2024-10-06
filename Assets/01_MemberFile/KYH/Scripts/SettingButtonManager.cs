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

    public GameObject quitPopUp;

    [SerializeField]
    private GameObject descriptionPanel;


    public void InvokeApp()
    {
        descriptionPanel.SetActive(false);
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
        folderManager.CancelButton();
        quitPopUp.SetActive(true);
    }

    private void YoutubeApp()
    {
        Process.Start("https://www.youtube.com/@jjangfish");
        folderManager.CancelButton();
    }

    private void HowControllApp()
    {

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
