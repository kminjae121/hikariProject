using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class CaptureObject : MonoBehaviour
{
    public PlaceObjSO captureSprite;

    private Transform uiPos;

    private void Awake()
    {
        uiPos = GameObject.Find("UIPos").GetComponent<Transform>();
    }


    public void CaptureFinish(int invenIdx)
    {
        if (invenIdx > 6)
            return;
        else
        {
            Collider2D collider = gameObject.GetComponent<Collider2D>();
            collider.enabled = false;
            collider.enabled = false;

            SpriteRenderer sprite = gameObject.GetComponent<SpriteRenderer>();
            sprite.sprite = captureSprite.sprite;
            if (gameObject.GetComponent<ObjectGather>() != null)
                gameObject.GetComponent<ObjectGather>().enabled = false;

            DoTweenSequence(sprite);
            Transform furniture = GameObject.Find("Gallury").transform.GetChild(invenIdx);
            furniture.GetComponent<FurnitureDistince>().placeObjSO = captureSprite;
            Image appImage = furniture.GetComponent<Image>();
            appImage.sprite = captureSprite.sprite;
        }
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
                    .Append(sprite.DOFade(0, 1)).JoinCallback(() => Debug.Log("½ÇÇàµÊ"));
    }
}
