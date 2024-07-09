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

    }

    private void BlinkTween()
    {
        glowScreenSeq = DOTween.Sequence();

        glowScreenSeq.Append(_glowScreen.DOFade(1, _interval));
        //glowScreenSeq.JoinCallback(TweenCallback(Random.Range(0.05f, 0.25f)));
        glowScreenSeq.SetLoops(-1, LoopType.Yoyo);
    }
}
