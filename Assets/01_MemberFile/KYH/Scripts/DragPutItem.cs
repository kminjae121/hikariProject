using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragPutItem : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        DragDropObject dragDropObject = dropped.GetComponent<DragDropObject>();
        dragDropObject.parentAfterDrag = transform;
    }
}
