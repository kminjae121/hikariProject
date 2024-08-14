using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragDropObject : MonoBehaviour , IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private CaptureManager captureManager;

    private Image image;
    private GameObject furnitureObj = null;

    [HideInInspector] public Transform parentAfterDrag;

    private void Awake()
    {
        captureManager = FindAnyObjectByType<CaptureManager>();
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
        furnitureObj.GetComponent<Rigidbody2D>().simulated = false;

        GetComponent<FurnitureDistince>().placeObjSO = null;
        GetComponent<Image>().sprite = null;
        furnitureObj.GetComponent<PlaceObj>().PlaceIt();
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
        PlaceObj placeObj = furnitureObj.GetComponent<PlaceObj>();
        if(furnitureObj.GetComponent<PlaceObj>().isPlaceTure)
        {
            placeObj.placeHelp.GetComponent<Rigidbody2D>().simulated = true;
            placeObj.placeHelp.GetComponent<SpriteRenderer>().color = Color.white;
        }
        else if(!furnitureObj.GetComponent<PlaceObj>().isPlaceTure)
        {
            placeObj.placeHelp.GetComponent<CaptureObject>().CaptureFinish(captureManager.inventoryIdx);
            captureManager.inventoryIdx++;
            Destroy(placeObj.placeHelp);
        }

        placeObj.isPlaceStart = false;

        Destroy(furnitureObj);
        furnitureObj = null;
        image.raycastTarget = true;
    }
}
