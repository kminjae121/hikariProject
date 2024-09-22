using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public interface IBrightDetection
{
    public void BrightnessDetection(bool canPlant, float brightStep);
    public bool isBrightOn { get; set; }
}

public class BrightFoothold : MonoBehaviour, IBrightDetection
{
    public BrightPlants brightPlants;

    public UnityEvent onInvokeBrightObj;
    public UnityEvent offInvokeBrightObj;

    public float brightnessLevel;

    public Action OnBrightnessDetection;

    public bool isTure; // ´êÀ½°¨Áö

    public bool isBrightOn { get; set; }

    public void BrightnessDetection(bool canPlant, float brightStep)
    {

        if (brightnessLevel == brightStep && canPlant)
        {
            onInvokeBrightObj?.Invoke();
        }
        if (brightnessLevel != brightStep || !canPlant)
        {
            offInvokeBrightObj?.Invoke();
        }
    }
}
