using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BrightFoothold : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer sprite;
    [SerializeField]
    private BrightPlants brightPlants;

    public float brightnessLevel;

    public Action OnBrightnessDetection;

    private Animator anim;
    private PolygonCollider2D collider;


    private void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponentInChildren<Animator>();
        collider = GetComponent<PolygonCollider2D>();
        OnBrightnessDetection += BrightnessDetection;
    }

    private void Update()
    {
        OnBrightnessDetection?.Invoke();
    }

    public void BrightnessDetection()
    {
        if (brightnessLevel > brightPlants.brightStep || brightPlants.isReach == false)
        {
            //sprite.material.color = new Color(sprite.material.color.r, sprite.material.color.g, sprite.material.color.b, 0f);\
            collider.isTrigger = true;
            anim.SetBool("Fold", true);
        }

        if (brightnessLevel == brightPlants.brightStep)
        {
            //sprite.material.color = new Color(sprite.material.color.r, sprite.material.color.g, sprite.material.color.b, 1f);
            collider.isTrigger = false;
            anim.SetBool("Fold", false);
        }
    }
}
