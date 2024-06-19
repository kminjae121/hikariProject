using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundSlider : MonoBehaviour
{
    public AudioMixer audioMixer;
    public float minVolume = -40;

    private void Awake()
    {
        SetMusicVolume(20);
    }

    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("BackGround", volume * minVolume);
    }
}
