using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageApp : MonoBehaviour
{
    public GameObject chromeLock;
    public GameObject powerPointLock;
    public GameObject chrome;
    public GameObject powerPoint;


    public void FinishTutorial()
    {
        chromeLock.SetActive(false);
        chrome.layer = 15;
        chrome.tag = "Application";
    }

    public void ClearChrome()
    {
        chromeLock.SetActive(true);
        chrome.layer = 0;
        chrome.tag = "Untagged";
        powerPointLock.SetActive(false);
        powerPoint.layer = 15;
        powerPoint.tag = "Application";
    }
}
