using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Intro : MonoBehaviour
{
    [SerializeField] private RawImage _glowScreen;
    [SerializeField] private float _interval = 0.05f;

    private Sequence glowScreenSeq;

    private void Start()
    {
        BlinkTween();
    }

    private void BlinkTween()
    {
        glowScreenSeq = DOTween.Sequence()
            .OnStart(() =>
            {
                _glowScreen.gameObject.SetActive(true);
            })
            .PrependInterval(5f)
            .Append(_glowScreen.DOFade(1, 0f))
            .Append(_glowScreen.transform.DOScaleX(400, 7f)).SetEase(Ease.OutCubic)
            .Append(_glowScreen.transform.DOScaleY(230, 2.5f)).SetEase(Ease.OutCubic)
            .Append(_glowScreen.DOFade(0, 1.25f));
    }

    private void IntroComplete()
    {

    }
}
