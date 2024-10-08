using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using DG.Tweening;

public class SeeShell : MonoBehaviour,IBrightDetection
{
    public Animator shellAnimation;
    private bool keepBright;
    public int keepBrightTime;
    private float currentBright;

    [SerializeField]
    private Light2D _light;

    private Tween tween;

    public bool isBrightOn { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public GameObject GameObject => gameObject;


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
            tween.Complete();
            keepBright = true;
            currentBright = brightStep;
            print(currentBright);
            _light.intensity = brightStep/2;
        }
        else if(!canPlant)
        {//닿지 않았을때
            if (keepBright)
            {
                //저장
                StartCoroutine(BrightRoutine());
            }
        }
    }

    private IEnumerator BrightRoutine()
    {
        yield return new WaitForSeconds(keepBrightTime);
        currentBright = 0f;
        tween = DOTween.To(() => _light.intensity, light => _light.intensity = light, 0, 2);
        keepBright = false;
    }
}
