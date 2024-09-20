using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;


public class SeeShell : MonoBehaviour,IBrightDetection
{
    public Animator shellAnimation;
    public bool keepBright;
    public float brightnessLevel;
    private float currentBright;

    [SerializeField]
    private Light2D _light;

    public void Attack()
    {

    }

    private void Awake()
    {
        _light.intensity = 0;
    }

    public void BrightnessDetection(bool canPlant, float brightStep)
    {
        if (canPlant && !keepBright)
        {//닿았을때
            keepBright = true;
            currentBright = brightStep;
            _light.intensity = brightStep / 10;
        }
        else
        {//닿지 않았을때
            if (keepBright)
            {
                //저장
                print("저장중");
            }
        }
    }
}
