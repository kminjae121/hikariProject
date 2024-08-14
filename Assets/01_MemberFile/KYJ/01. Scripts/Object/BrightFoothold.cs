using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrightFoothold : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer sprite;
    [SerializeField]
    private BrightPlants plants;
    private BoxCollider2D boxCollider;
    public float brightStep;

    private bool isReach;

    private void Awake()
    {
        boxCollider = GetComponentInChildren<BoxCollider2D>();
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
        if (brightStep > plants.brightStep || plants.isOn == false)
        {
            
        }

        if (brightStep <= plants.brightStep && plants.isOn == true)
        {
            sprite.material.color = new Color(sprite.material.color.r, sprite.material.color.g, sprite.material.color.b, 1f);
        }
    }
}
