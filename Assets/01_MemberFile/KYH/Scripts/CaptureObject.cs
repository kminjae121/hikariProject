using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CaptureObject : MonoBehaviour
{
    public Sprite captureSprite;
    private Sequence changeUI = DOTween.Sequence();

    [Header("인벤토리 위치")]
    [SerializeField]
    private Transform uiPos;

    public void CaptureFinish()
    {
        Collider2D collider =  gameObject?.GetComponent<Collider2D>();
        collider.enabled = false;

        gameObject.GetComponent<SpriteRenderer>().sprite = captureSprite;
        changeUI.Prepend(gameObject.transform.DOScale(new Vector3(3f,3f,0), 1))
            .Append(gameObject.transform.DOScale(1f, 1))
            .Append(gameObject.transform.DOMove(new Vector2(uiPos.position.x,uiPos.position.y), 2f));
        CanHoldObject();
    }

    public void CanHoldObject()
    {

    }
}
