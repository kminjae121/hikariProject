using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class EffectSlider : MonoBehaviour
{
    public AudioMixer audiomixer;
    public float minVolume = -40;

    private void Awake()
    {
        EffectSoundSlider(0);
    }

    public void EffectSoundSlider(float volume)
    {
        audiomixer.SetFloat("Effect", volume * minVolume);
    }    
}
