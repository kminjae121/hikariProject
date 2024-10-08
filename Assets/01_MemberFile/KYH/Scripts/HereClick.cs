using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HereClick : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<RectTransform>().DOLocalMoveX(-186.19f, 1).SetLoops(-1, LoopType.Yoyo);
    }
}
