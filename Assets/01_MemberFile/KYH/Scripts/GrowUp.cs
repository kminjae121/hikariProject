using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GrowUp : MonoBehaviour
{
    private void Start()
    {
        gameObject.GetComponent<RectTransform>().DOScale(5.2f, 1).SetLoops(-1,LoopType.Yoyo);
    }
}
