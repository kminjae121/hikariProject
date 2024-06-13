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
    private List<GameObject> LowBrightObject;
    [SerializeField]
    private List<GameObject> MiddleBrightObject;
    [SerializeField]
    private List<GameObject> HighBrightObject;


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

    public void Brightness()
    {
        if(slider.value >= 1 && slider.value <= 3)
        {
            for(int i =0; i<LowBrightObject.Count; i++)
            {
                render = LowBrightObject[i].GetComponent<SpriteRenderer>();
                render.DOFade(endValue: 1, duration: 1);
            }
        }
        else
        {
            render.DOFade(endValue: 0, duration: 1);
        }
    }
}
