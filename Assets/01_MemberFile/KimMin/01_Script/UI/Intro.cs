using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Intro : MonoBehaviour
{
    [SerializeField] private RawImage _glowScreen;
    [SerializeField] private RawImage _background;

    private Sequence glowScreenSeq;

    private void Awake()
    {
        _background.gameObject.SetActive(true);
        _glowScreen.gameObject.SetActive(true);

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
            .Append(_glowScreen.transform.DOScaleX(200, 7f)).SetEase(Ease.OutCubic)
            .Join(_glowScreen.transform.DOScaleY(0.4f, 7f)).SetEase(Ease.OutCubic)
            .Append(_glowScreen.transform.DOScaleY(120, 2.5f)).SetEase(Ease.OutCubic)
            .Append(_background.DOFade(0, 0f))
            .Append(_glowScreen.DOFade(0, 1.25f))
            .OnComplete(() => transform.gameObject.SetActive(false));
    }
}
