using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    [Header("--------------BackGroundAudio--------------")]
    [SerializeField] AudioSource music1;
    [SerializeField] AudioSource music2;
    [SerializeField] AudioSource music3;
    [SerializeField] AudioSource music4;

    private string _currentScene;

    private void Awake()
    {
        music1 = GameObject.Find("CaptureSoundAsset").GetComponent<AudioSource>();
        music2 = GameObject.Find("MainSoundAsset").GetComponent<AudioSource>();
        music3 = GameObject.Find("SeaSoundAsset").GetComponent<AudioSource>();
        music4 = GameObject.Find("VirusSoundAsset").GetComponent<AudioSource>();
    }

    private void Start()
    {
        music1.Pause();
        music2.Pause();
        music3.Pause();
        music4.Pause();
        _currentScene = SceneManager.GetActiveScene().name;

        switch (_currentScene)
        {
            case "WindowScene":
                music2.Play();
                break;
            case "CaptureStage":
                music1.Play();
                break;
            case "KimMin":
                music3.Play();
                break;
            default:
                music4.Play();
                break;
        }
    }

    private void Update()
    {
    }

    public void ChangeMainStageVolume(AudioClip mainClip)
    {
        music2.clip = mainClip;
    }
}
