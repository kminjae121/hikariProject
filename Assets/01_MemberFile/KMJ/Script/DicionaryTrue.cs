using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DicionaryTrue : MonoBehaviour
{
    [SerializeField] private GameObject _dicionary;

    private bool _isOpen;

    private void Awake()
    {
        _isOpen = true;
    }
    public void ButtonClick()
    {
        if (_isOpen == true)
        {
            _dicionary.GetComponent<RectTransform>().DOAnchorPosX(-675, 0.4f).SetEase(Ease.OutQuint);
            _isOpen = false;
        }
        else if(_isOpen == false)
        {
            _dicionary.GetComponent<RectTransform>().DOAnchorPosX(-1300, 0.4f).SetEase(Ease.OutQuint);
            _isOpen = true;
        }
    }
}
