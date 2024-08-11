using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Foothold2 : Foothold
{
    protected override void Awake()
    {
        base.Awake();
    }

    private void Update()
    {
        StartCoroutine(DownMoveFoothold(3f));
        StartCoroutine(UpMoveFoothold(3f));
    }


    protected override IEnumerator UpMoveFoothold(float stopTime)
    {
        return base.UpMoveFoothold(stopTime);
    }

    protected override IEnumerator DownMoveFoothold(float stopTime)
    {
        return base.DownMoveFoothold(stopTime);
    }
}
