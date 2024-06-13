using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundSlider : MonoBehaviour
{
    public AudioSource BackgroundVolume;
    public AudioSource BackGoundVolume2;


    public void SetMusicVolume(float volume)
    {
        BackgroundVolume.volume = volume; 
        BackGoundVolume2.volume = volume;
    }
}
