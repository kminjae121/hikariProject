using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [Header("--------------BackGroundAudio--------------")]
    [SerializeField] AudioClip[] music;


    [SerializeField]
    private AudioSource bgmAudioPlayer;

    private Dictionary<string, AudioClip> audioDic = new Dictionary<string, AudioClip>();
    //private string _currentScene;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);


        foreach (AudioClip audioClip in music)
        {
            audioDic.Add(audioClip.name, audioClip);
        }

        bgmAudioPlayer.clip = null;
    }

    public void ChangeMainStageVolume(string mainClip, bool isPlay)
    {
        bgmAudioPlayer.clip = audioDic[mainClip];
        if (isPlay)
            bgmAudioPlayer.Play();
        else
            bgmAudioPlayer.Pause();
    }
}
