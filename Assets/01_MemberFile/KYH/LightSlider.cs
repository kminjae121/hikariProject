using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class LightSlider : MonoBehaviour
{
    [SerializeField]
    private Slider slider;

    private bool sliderOn;

    [SerializeField]
    private List<LightLevelBlock> _lightLevelBlockList;

    private Tween[] _lowBrightTween;
    private Tween[] _middleBrightTween;
    private Tween[] _highBrightTween;

    //[SerializeField, ColorUsage(showAlpha:false, hdr:true)]
    //private Color color;

    [SerializeField] private string str; //배우기


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
        GetComponentsInChildren(_lightLevelBlockList);
    }

    private void Start()
    {
        //_lowBrightTween = new Tween[LowBrightObject.Count];
        //_middleBrightTween = new Tween[MiddleBrightObject.Count];
        //_highBrightTween = new Tween[HighBrightObject.Count];

        //if (slider.value >= 0 && slider.value <= 3)
        //{
        //    for (int i = 0; i < LowBrightObject.Count; i++)
        //    {
        //        render = LowBrightObject[i].GetComponent<SpriteRenderer>();
        //        _lowBrightTween[i] = render.DOFade(endValue: 1, duration: 1);
        //    }
        //}
        //else if (slider.value >= 4 && slider.value <= 7)
        //{
        //    for (int i = 0; i < MiddleBrightObject.Count; i++)
        //    {
        //        render = MiddleBrightObject[i].GetComponent<SpriteRenderer>();
        //        _middleBrightTween[i] = render.DOFade(endValue: 1, duration: 1);
        //    }
        //}
        //else if (slider.value >= 8 && slider.value <= 10)
        //{
        //    for (int i = 0; i < HighBrightObject.Count; i++)
        //    {
        //        render = HighBrightObject[i].GetComponent<SpriteRenderer>();
        //        _highBrightTween[i] = render.DOFade(endValue: 1, duration: 1);
        //    }
        //}
    }



    public void Brightness()
    {
        for(int i =0; i < _lightLevelBlockList.Count; i++)
        {
            if(slider.value >= 0 && slider.value <=3)
            {
                if (_lightLevelBlockList[i].lightLevel == 1)
                {
                    SpriteRenderer render = _lightLevelBlockList[i].gameObject.GetComponent<SpriteRenderer>();
                    render.DOFade(1, 1);
                    print("엄");
                }
                else
                {
                    SpriteRenderer render = _lightLevelBlockList[i].gameObject.GetComponent<SpriteRenderer>();
                    render.DOFade(0, 1);
                }
            }
            else if(slider.value >= 4 && slider.value <= 7)
            {
                if (_lightLevelBlockList[i].lightLevel == 2)
                {
                    SpriteRenderer render = _lightLevelBlockList[i].gameObject.GetComponent<SpriteRenderer>();
                    render.DOFade(1, 1);
                    print("엄2");
                }
                else
                {
                    SpriteRenderer render = _lightLevelBlockList[i].gameObject.GetComponent<SpriteRenderer>();
                    render.DOFade(0, 1);
                }
            }
            else if (slider.value >= 8 && slider.value <= 10)
            {
                if (_lightLevelBlockList[i].lightLevel == 3)
                {
                    SpriteRenderer render = _lightLevelBlockList[i].gameObject.GetComponent<SpriteRenderer>();
                    render.DOFade(1, 1);
                    print("엄3");
                }
                else
                {
                    SpriteRenderer render = _lightLevelBlockList[i].gameObject.GetComponent<SpriteRenderer>();
                    render.DOFade(0, 1);
                }
            }
        }
    }

    private void Fade()
    {

    }
}
