using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundSlider : MonoBehaviour
{
    public AudioMixer audioMixer;
    public float maxVolume = 20;
    public float minVolume = -80;

    private void Awake()
    {
        SetMusicVolume(0);
    }

    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("BackGround", volume * maxVolume);
    }
}
