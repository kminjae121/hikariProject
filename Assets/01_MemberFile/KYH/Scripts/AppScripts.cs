using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppScripts : MonoBehaviour
{
    [SerializeField]
    private Sprite appImage;

    private SpriteRenderer appRendering;

    private void Awake()
    {
        appRendering = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        appRendering.sprite = appImage;
    }
}
