using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class LockfadeIn : MonoBehaviour
{
    public SpriteRenderer lockObj;

    Sequence _seq;

    // const int LIST_COUNT = 3;
    // List<int> _list = new List<int>(LIST_COUNT);

    public void LockFade()
    {
        //Span<int> arr = new int[2];

        //arr[0] = 0;
        //arr[1] = 0;

        //transform.TransformPoints(new Vector3[] { });

        SafeKill(_seq);

        _seq = DOTween.Sequence()
            .Append(lockObj.DOFade(duration: 1, endValue: 1))
            .Append(lockObj.DOFade(duration: 1, endValue: 0));
    }

    public void SafeKill(Tween tween)
    {
        if(tween is not null && tween.IsActive())
            tween.Complete();
    }

}
