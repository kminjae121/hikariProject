using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Diagnostics;
using System.Reflection;

public class AppDescription : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI descriptionText;
    public App currentAPP;

    [SerializeField]
    private GameObject descriptionPanel;



    public void DescriptionApp()
    {
        GetType().GetMethod($"{currentAPP}Description", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).Invoke(this, null);
        //GetType().GetMethod("currnetApp").Invoke(this, new object[] {3, 4 });
    }

    private void WeatherDescription()
    {
        descriptionPanel.SetActive(true);
        descriptionText.text = "지금 날씨는 어떻지?";
    }

    private void ChromeDescription()
    {
        descriptionPanel.SetActive(true);
        descriptionText.text = "1번째 과제인 자료 찾기를 위해서 들어가야할 곳이다";
    }

    private void ExitDescription()
    {
        descriptionPanel.SetActive(true);
        descriptionText.text = "역시 과제는 한숨 자고나서 해야지";
    }

    private void YoutubeDescription()
    {
        descriptionPanel.SetActive(true);
        descriptionText.text = "히카리의 게임 소개영상으로 연결되어있다";
    }

    private void HowControllDescription()
    {
        descriptionPanel.SetActive(true);
        descriptionText.text = "어떻게 게임을 해야하는지 조작법을 볼수있다";
    }
    private void PortPolioDescription()
    {
        descriptionPanel.SetActive(true);
        descriptionText.text = "히카리를 투표하러 바로 갈수있다";
    }
    private void PowerPointDescription()
    {
        descriptionPanel.SetActive(true);
        descriptionText.text = "2번째 과제인 ppt만들기를 하러가는 곳이다";
    }
    private void GameDescription()
    {
        descriptionPanel.SetActive(true);
        descriptionText.text = "유일하게 다운로드 되어있는 게임이다";
    }
}
