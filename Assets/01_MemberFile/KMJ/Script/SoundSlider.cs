using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundSlider : MonoBehaviour
{
    public AudioMixer audioMixer;
    //[SerializeField] private AudioManager _audioManager;
    private List<AudioClip> MainAudioClip = new List<AudioClip>();

    private void Start()
    {
        SetBackGroundMusicVolume(80);
        SetBackGroundMusicVolume(80);
    }
    private void Update()
    {
        
    }

    public void SetEffectMusicVolume(float volume)
    {
        audioMixer.SetFloat("Effect", volume-=80);
    }

    public void SetBackGroundMusicVolume(float volume)
    {
        audioMixer.SetFloat("BackGround", volume-=80);
    }
}
