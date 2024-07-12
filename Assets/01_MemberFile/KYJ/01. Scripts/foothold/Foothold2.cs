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
        StartCoroutine(MoveFoothold(3f));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Water"))
        {
            isBack = true;
        }
    }

    protected override IEnumerator MoveFoothold(float stopTime)
    {
        return base.MoveFoothold(stopTime);
    }

}


//랜덤한 시간동안 멈췄다가 떨어지게 만들자. --> 랜덤하게 엉망으로 발판들이 들쑥날쑥 하겠지. / 기존 발판 스크립트에서 머물렀다 올라오는 시간만 랜덤값으로 바꾸자.
// 버튼 감지를 만들어. / 버튼이 플레이어, 물체에 접촉했을 경우 -> bool 값으로 여부 확인하자
// 버튼 감지가 이루어졌을 때! 발판이 일렬로 정렬되게 만들자. -> bool 값이 확인되면 기존 발판을 원래 위치로 되돌리고, 움직임 메서드의 시간을 랜덤값에서 고정된 값으로 바꾸자.

