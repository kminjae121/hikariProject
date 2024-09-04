using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BrightFoothold : MonoBehaviour
{
    public BrightPlants brightPlants;

    public float brightnessLevel;

    public Action OnBrightnessDetection;

    private Animator anim;
    private PolygonCollider2D polygonCollider;

    public bool isTure; // ´êÀ½°¨Áö

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        polygonCollider = GetComponent<PolygonCollider2D>();
    }

    public void BrightnessDetection(bool canPlant, float brightStep)
    {
        if (brightnessLevel == brightStep && canPlant)
        {
            polygonCollider.isTrigger = false;
            anim.SetBool("Fold", false);
        }
        if (brightnessLevel != brightStep || !canPlant)
        {
            polygonCollider.isTrigger = true;
            anim.SetBool("Fold", true);
        }
    }
}
