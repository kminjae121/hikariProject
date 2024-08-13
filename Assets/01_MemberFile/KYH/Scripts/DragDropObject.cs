using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragDropObject : MonoBehaviour , IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Image image;

    [HideInInspector] public Transform parentAfterDrag;
    [HideInInspector] public bool isPlaceIt;
    [HideInInspector] public bool isMove;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
        isMove = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
        print("잡고있다");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isMove = false;
        print("아이쿠 놓쳤네");
        if(isPlaceIt)
        {
            print("배치");
        }
        transform.SetParent(parentAfterDrag);
        image.raycastTarget = true;
    }
}
