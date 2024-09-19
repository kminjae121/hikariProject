using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class BrightFoothold : MonoBehaviour
{
    public BrightPlants brightPlants;

    public UnityEvent onInvokeBrightObj;
    public UnityEvent offInvokeBrightObj;

    public float brightnessLevel;

    public Action OnBrightnessDetection;



    public bool isTure; // ´êÀ½°¨Áö

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
