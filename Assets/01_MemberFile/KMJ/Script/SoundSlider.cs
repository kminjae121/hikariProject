using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundSlider : MonoBehaviour
{

    public AudioMixer audioMixer;
    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("BackGround", Mathf.Log10(volume));
    }
}
