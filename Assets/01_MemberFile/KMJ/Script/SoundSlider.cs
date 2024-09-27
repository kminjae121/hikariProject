using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundSlider : MonoBehaviour
{
    public AudioMixer audioMixer;


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
