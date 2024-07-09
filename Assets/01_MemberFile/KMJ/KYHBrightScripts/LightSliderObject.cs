using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class LightSliderObject : MonoBehaviour
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
        Brightness();
    }



    public void Brightness()
    {
        for (int i = 0; i < _lightLevelBlockList.Count; i++)
        {
            if (slider.value >= 0 && slider.value <= 3)
            {
                if (_lightLevelBlockList[i].lightLevel == 1)
                {
                    FadeLook(i);
                }
                else
                {
                    FadeHide(i);
                }
            }
            else if (slider.value >= 4 && slider.value <= 7)
            {
                if (_lightLevelBlockList[i].lightLevel == 2)
                {
                    FadeLook(i);
                }
                else
                {
                    FadeHide(i);
                }
            }
            else if (slider.value >= 8 && slider.value <= 10)
            {
                if (_lightLevelBlockList[i].lightLevel == 3)
                {
                    FadeLook(i);
                }
                else
                {
                    FadeHide(i);
                }
            }
        }
    }

    private void FadeLook(int index)
    {
        
        SpriteRenderer render = _lightLevelBlockList[index].gameObject.GetComponent<SpriteRenderer>();
        render.DOFade(1, 1);
        StartCoroutine(SetFalseObject(index, false));
        //Image renderUI = _lightLevelBlockList[index].gameObject.GetComponent<Image>();
        //renderUI.DOFade(1, 1);
    }

    private void FadeHide(int index)
    {
        SpriteRenderer render = _lightLevelBlockList[index].gameObject.GetComponent<SpriteRenderer>();
        render.DOFade(0, 1);
        StartCoroutine(SetFalseObject(index, true));
        //Image renderUI = _lightLevelBlockList[index].gameObject.GetComponent<Image>();
        //renderUI.DOFade(0, 1);
    }

    private IEnumerator SetFalseObject(int index, bool statue)
    {
        if(statue)
        {
            yield return new WaitForSecondsRealtime(1f);
            Collider2D collision = _lightLevelBlockList[index].gameObject.GetComponent<Collider2D>();
            collision.enabled = false;
        }
        else
        {
            yield return new WaitForSecondsRealtime(1f);
            Collider2D collision = _lightLevelBlockList[index].gameObject.GetComponent<Collider2D>();
            collision.enabled = true;
        }
    }
}
