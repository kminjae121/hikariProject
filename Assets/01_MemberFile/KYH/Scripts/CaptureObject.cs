using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class CaptureObject : MonoBehaviour
{
    public Sprite captureSprite;

    [Header("인벤토리 위치")]
    [SerializeField]
    private Transform uiPos;


    public void CaptureFinish(int invenIdx)
    {
        Collider2D collider = gameObject?.GetComponent<Collider2D>();
        collider.enabled = false;

        SpriteRenderer sprite = gameObject.GetComponent<SpriteRenderer>();
        sprite.sprite = captureSprite;
        DoTweenSequence(sprite);

        Image appImage = GameObject.Find("App" + invenIdx).GetComponent<Image>();
        appImage.sprite = captureSprite;
    }

    private void DoTweenSequence(SpriteRenderer sprite)
    {
        Sequence changeUI = DOTween.Sequence()
                    .Prepend(gameObject.transform
                    .DOScale(2f, 0.1f).SetEase(Ease.OutQuart))
                    .Append(gameObject.transform
                    .DOScale(1f, 1f).SetEase(Ease.OutCirc))
                    .Join(gameObject.transform
                    .DOMove(new Vector2(uiPos.position.x, uiPos.position.y), 3f)
                    .SetEase(Ease.InOutQuint))
                    .Append(sprite.DOFade(0, 1)).JoinCallback(() => Debug.Log("실행됨"));
    }
}
