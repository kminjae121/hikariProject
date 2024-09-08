using UnityEngine;
using DG.Tweening;

public class ScreenMove : MonoBehaviour
{
    [SerializeField]
    private Ease ease;
    [SerializeField]
    private float yMoveInstance;

    private void Start()
    {
        DOYMove();
    }

    private void DOYMove()
    {
        gameObject.GetComponent<RectTransform>().DOLocalMoveY(yMoveInstance, 1).SetLoops(-1, LoopType.Yoyo).SetEase(ease);
    }
}
