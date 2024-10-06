using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Intro : MonoBehaviour
{
    [SerializeField] private RawImage _glowScreen;
    [SerializeField] private RawImage _background;

    [SerializeField]
    private ParticleSystem particleSystem;

    [SerializeField]
    private Image blueBackGround;

    private Sequence glowScreenSeq;

    [SerializeField]
    private GameObject windowSideVolume;
    [SerializeField]
    private GameObject windowScreenNoise;

    [SerializeField]
    private GameObject[] outLine;

    public GameObject onButton;

    public void BlinkTween()
    {
        _background.gameObject.SetActive(true);
        _glowScreen.gameObject.SetActive(true);

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
            .JoinCallback(() => particleSystem.Play())
            .Join(blueBackGround.DOColor(new Color(150, 170, 255, 255), 5f))
            .Append(_background.DOFade(0, 0f))
            .JoinCallback(() => windowScreenNoise.SetActive(true))
            .JoinCallback(SetActiveOutLine())
            .JoinCallback(() => onButton.SetActive(true))
            .Append(_glowScreen.DOFade(0, 1.25f))
            .JoinCallback(()=> particleSystem.Stop())
            .OnComplete(() => transform.gameObject.SetActive(false));
    }

    private TweenCallback SetActiveOutLine()
    {
        for (int i = 0; i < outLine.Length; i++)
        { outLine[i].SetActive(true); }
        return null;
    }
}
