using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BrightFoothold : MonoBehaviour
{
    [SerializeField]
    private BrightPlants brightPlants;

    public float brightnessLevel;

    public Action OnBrightnessDetection;

    private Animator anim;
    private PolygonCollider2D polygonCollider;


    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        polygonCollider = GetComponent<PolygonCollider2D>();
        OnBrightnessDetection += BrightnessDetection;
    }

    private void Update()
    {
        OnBrightnessDetection?.Invoke();
    }

    public void BrightnessDetection()
    {
        if (brightnessLevel > brightPlants.brightStep ||  brightnessLevel < brightPlants.brightStep || brightPlants.isReach == false)
        {
            polygonCollider.isTrigger = true;
            anim.SetBool("Fold", true);
        }

        if (brightnessLevel == brightPlants.brightStep && brightPlants.isReach == true)
        {
            polygonCollider.isTrigger = false;
            anim.SetBool("Fold", false);
        }
    }
}
