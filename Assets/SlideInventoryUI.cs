using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SlideInventoryUI : MonoBehaviour
{
    private HorizontalLayoutGroup layoutGroup;
    private bool isOpenedInventory = false;

    [SerializeField]
    private float maxArea;
    
    private void Awake()
    {
        layoutGroup = GetComponent<HorizontalLayoutGroup>();
    }

    private void Start()
    {
        isOpenedInventory = true;
        OnClickButton();
    }

    public void OnClickButton()
    {
        RotateAnimation();
        if (!isOpenedInventory)
        {
            isOpenedInventory = true;
            StartCoroutine(SpacingChangeUI(maxArea));
        }
        else
        {
            isOpenedInventory = false;
            StartCoroutine(SpacingChangeUI(-100f));
        }
    }

    private IEnumerator SpacingChangeUI(float max)
    {
        yield return DOTween.Sequence().Append(DOTween.To(() => layoutGroup.spacing, x => layoutGroup.spacing = x, max, 1));
        if (max > 0)
        {
            for(int i=0; i<gameObject.GetComponentsInChildren<Image>().Length; i++)
                gameObject.GetComponentsInChildren<Image>()[i].DOFade(0, 0.3f);
        }
        else
        {
            for (int i = 0; i < gameObject.GetComponentsInChildren<Image>().Length; i++)
                gameObject.GetComponentsInChildren<Image>()[i].DOFade(1, 0.3f);
        }
    }

    private void RotateAnimation()
    {

    }
}
