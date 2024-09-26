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

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        music1 = GameObject.Find("CaptureSoundAsset").GetComponent<AudioSource>();
        music2 = GameObject.Find("MainSoundAsset").GetComponent<AudioSource>();
        music3 = GameObject.Find("SeaSoundAsset").GetComponent<AudioSource>();
        music4 = GameObject.Find("VirusSoundAsset").GetComponent<AudioSource>();
    }

    private void Update()
    {
        
    }
}
