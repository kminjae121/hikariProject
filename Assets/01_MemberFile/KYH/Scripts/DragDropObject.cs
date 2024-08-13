using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragDropObject : MonoBehaviour , IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Image image;
    private GameObject furnitureObj = null;

    private bool isPlace;

    [HideInInspector] public Transform parentAfterDrag;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        
        //parentAfterDrag = transform.parent;
        //transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        image.raycastTarget = false;

        PlaceObjSO placeObjSO = GetComponent<FurnitureDistince>().placeObjSO;
        GameObject furniture = placeObjSO.prefab;
        furnitureObj = Instantiate(furniture, transform);

        GetComponent<FurnitureDistince>().placeObjSO = null;
        GetComponent<Image>().sprite = null;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        furnitureObj.transform.position = pos;

        print(furnitureObj.transform.position);
        print(furnitureObj.name);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Destroy(furnitureObj);
        furnitureObj = null;
        image.raycastTarget = true;
    }
}
