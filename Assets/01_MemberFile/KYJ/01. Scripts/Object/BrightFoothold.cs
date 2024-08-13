using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrightFoothold : MonoBehaviour
{
    private SpriteRenderer sprite;
    private BrightPlants plants;
    public float brightStep;

    private bool isReach;

    private void Awake()
    {
        plants = GameObject.Find("Visual").GetComponent<BrightPlants>();
        sprite = GameObject.Find("Square").GetComponent<SpriteRenderer>();

        sprite.material.color = new Color(sprite.material.color.r, sprite.material.color.g, sprite.material.color.b, 0f);
 
    }

    private void Update()
    {
        BrightStep();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isReach = true;
        }
    }

    public void BrightStep()
    {
        if (brightStep != plants.brightStep)
        {
            sprite.material.color = new Color(sprite.material.color.r, sprite.material.color.g, sprite.material.color.b, 0f);
        }

        if (brightStep <= plants.brightStep)
        {
            sprite.material.color = new Color(sprite.material.color.r, sprite.material.color.g, sprite.material.color.b, 1f);
        }
    }
}
