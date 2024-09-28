using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public interface IBrightDetection
{
    public void BrightnessDetection(bool canPlant, float brightStep);
    public bool isBrightOn { get; set; }
    public GameObject GameObject { get; }
}

public class BrightFoothold : MonoBehaviour, IBrightDetection
{
    [Header("Luminescent Plants Visual Input")]
    public BrightPlants brightPlants;

    [Header("Luminescent Plants Event")]
    public UnityEvent onInvokeBrightObj;
    public UnityEvent offInvokeBrightObj;

    [Header("Foothold Setting")]
    public float footholdBrightnessLevel;
    public bool isBrightOn { get; set; }

    public Action OnBrightnessDetection;
    public GameObject GameObject => gameObject;

     

    public void BrightnessDetection(bool canPlant, float brightStep)
    {
        if (footholdBrightnessLevel == brightStep && canPlant)
        {
            onInvokeBrightObj?.Invoke();
        }
        if (footholdBrightnessLevel != brightStep || !canPlant)
        {
            offInvokeBrightObj?.Invoke();
        }
    }
}
