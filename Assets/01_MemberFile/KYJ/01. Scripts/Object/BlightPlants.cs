using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlightPlants : MonoBehaviour
{
    private LuminescentPlants plants;
    private SpriteRenderer sprite;

    [ColorUsage(true, true)]
    public Color _color;
    private float brightStep= Mathf.Clamp(0, 0, 4);

    private void Awake()
    {
        plants = GameObject.Find("LuminescentPlants").GetComponent<LuminescentPlants>();
        sprite = GetComponent<SpriteRenderer>();

        plants.OnPlants += BrightnessControl;
    }



    private void BrightnessControl()
    {
        sprite.color = _color;
        if (Input.GetKeyDown(KeyCode.I))
        {
            _color = _color * 5f;
            brightStep += 1;
            print(brightStep);
        }
        else if (Input.GetKeyDown(KeyCode.U))
        {
            _color = _color * 0.1f;
            brightStep -= 1;
            print(brightStep);
        }
    }
}
