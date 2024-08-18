using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BrightFoothold : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer sprite;
    [SerializeField]
    public BrightPlants brightPlants;

    public float brightnessLevel;

    public Action OnBrightnessDetection;

    private void Awake()
    {
        OnBrightnessDetection += BrightnessDetection
;
    }

    private void Update()
    {
        OnBrightnessDetection?.Invoke();
    }

    public void BrightnessDetection()
    {
        if (brightnessLevel > brightPlants.brightStep || brightPlants.isReach == false)
        {
            sprite.material.color = new Color(sprite.material.color.r, sprite.material.color.g, sprite.material.color.b, 0f);
        }

        if (brightnessLevel <= brightPlants.brightStep && brightPlants.isReach == true)
        {
            sprite.material.color = new Color(sprite.material.color.r, sprite.material.color.g, sprite.material.color.b, 1f);
        }
    }
}
