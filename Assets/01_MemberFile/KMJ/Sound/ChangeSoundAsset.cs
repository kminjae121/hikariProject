using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSoundAsset : MonoBehaviour
{
    private string _currentSceneName;
    private void Awake()
    {
        
    }

    private void Start()
    {
        _currentSceneName = SceneManager.GetActiveScene().name;
        ChanegeAsset();
    }
    private void Update()
    {
    }

    private void ChanegeAsset()
    {
        switch(_currentSceneName)
        {
            case "CaptureStage":
                SoundManager.Instance.ChangeMainStageVolume("CaptureStageSound", true,ISOund.BGM);
                break;
            case "KimMin":
                SoundManager.Instance.ChangeMainStageVolume("Sea Stage Sound", true, ISOund.BGM);
                break;
        }
    }
}
