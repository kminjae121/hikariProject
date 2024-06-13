using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BrightSlider : MonoBehaviour
{
    [SerializeField]
    private Slider slider;

    private bool sliderOn;

    [SerializeField]
    private List<GameObject> LowBrightObject;
    [SerializeField]
    private List<GameObject> MiddleBrightObject;
    [SerializeField]
    private List<GameObject> HighBrightObject;



    private Tween[] _lowBrightTween;
    private Tween[] _middleBrightTween;
    private Tween[] _highBrightTween;

    //[SerializeField, ColorUsage(showAlpha:false, hdr:true)]
    //private Color color;

    [SerializeField] private string str; //배우기

    private SpriteRenderer render;

    public bool SliderOn
    {
        get
        {
            sliderOn = slider.interactable;
            return sliderOn;
        }
        set
        {
            sliderOn = value;
        }
    }

    private void Awake()
    {
        slider.interactable = true; //슬라이더의 상호작용 여부

    }

    private void Start()
    {
        _lowBrightTween = new Tween[LowBrightObject.Count];
        _middleBrightTween = new Tween[MiddleBrightObject.Count];
        _highBrightTween = new Tween[HighBrightObject.Count];

        if (slider.value >= 0 && slider.value <= 3)
        {
            for (int i = 0; i < LowBrightObject.Count; i++)
            {
                render = LowBrightObject[i].GetComponent<SpriteRenderer>();
                _lowBrightTween[i] = render.DOFade(endValue: 1, duration: 1);
            }
        }
        else if (slider.value >= 4 && slider.value <= 7)
        {
            for (int i = 0; i < MiddleBrightObject.Count; i++)
            {
                render = MiddleBrightObject[i].GetComponent<SpriteRenderer>();
                _middleBrightTween[i] = render.DOFade(endValue: 1, duration: 1);
            }
        }
        else if (slider.value >= 8 && slider.value <= 10)
        {
            for (int i = 0; i < HighBrightObject.Count; i++)
            {
                render = HighBrightObject[i].GetComponent<SpriteRenderer>();
                _highBrightTween[i] = render.DOFade(endValue: 1, duration: 1);
            }
        }
    }



    public void Brightness()
    {
        if (slider.value >= 0 && slider.value <= 3)
        {
            for (int i = 0; i < LowBrightObject.Count; i++)
            {
                if (_middleBrightTween[i] is not null && _middleBrightTween[i].active)
                    _middleBrightTween[i].Kill();

                _lowBrightTween[i] = render.DOFade(endValue: 1, duration: 1);
                render = LowBrightObject[i].GetComponent<SpriteRenderer>();
            }
        }
        else if (slider.value >= 4 && slider.value <= 7)
        {
            for (int i = 0; i < MiddleBrightObject.Count; i++)
            {
                if (_middleBrightTween[i] is not null && _middleBrightTween[i].active)
                    _middleBrightTween[i].Kill();

                render = MiddleBrightObject[i].GetComponent<SpriteRenderer>();
                _middleBrightTween[i] = render.DOFade(endValue: 1, duration: 1);
            }
        }
        else if (slider.value >= 8 && slider.value <= 10)
        {
            for (int i = 0; i < HighBrightObject.Count; i++)
            {
                if (_highBrightTween[i] is not null && _highBrightTween[i].active)
                    _highBrightTween[i].Kill();

                render = HighBrightObject[i].GetComponent<SpriteRenderer>();
                _highBrightTween[i] = render.DOFade(endValue: 1, duration: 1);
            }
        }
        else
        {
            render.DOFade(endValue: 0, duration: 1);
        }
    }
}
