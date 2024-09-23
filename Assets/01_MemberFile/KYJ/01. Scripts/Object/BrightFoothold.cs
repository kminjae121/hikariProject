using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public interface IBrightDetection
{
    public void BrightnessDetection(bool canPlant, float brightStep);
}

public class BrightFoothold : MonoBehaviour, IBrightDetection
{
    public BrightPlants brightPlants;

    public UnityEvent onInvokeBrightObj;
    public UnityEvent offInvokeBrightObj;

    public float brightnessLevel;

    public Action OnBrightnessDetection;

    private bool canPlant;

    private float size = 3f;
    public LayerMask luminescentPlant;

    public void BrightnessDetection(bool canPlant, float brightStep)
    {
        if (brightnessLevel == brightStep && canPlant)
        {
            onInvokeBrightObj?.Invoke();
            //this.canPlant = canPlant;
        }
        if (brightnessLevel != brightStep || !canPlant)
        {
            offInvokeBrightObj?.Invoke();
        }
    }

    //private void Update()
    //{
    //    if (canPlant)
    //    {
    //        Collider2D[] collision = Physics2D.OverlapCircleAll(transform.position, size, luminescentPlant);
    //        if (collision == null)
    //        {
    //            BrightnessDetection(false,-1);
    //            canPlant = false;
    //        }
    //    }

    //}
}
