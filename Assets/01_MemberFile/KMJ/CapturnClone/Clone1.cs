using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.EventSystems;

public class Clone1 : MonoBehaviour
{
    private CaptureManager captureManager;

    private Image image;
    private GameObject furnitureObj = null;
    private ObjectGather _objectFuntion;

    [HideInInspector] public Transform parentAfterDrag;

    private void Awake()
    {
        captureManager = FindAnyObjectByType<CaptureManager>();
        image = GetComponent<Image>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {

        transform.SetAsLastSibling();
        //parentAfterDrag = transform.parent;
        //transform.SetParent(transform.root);
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
        if (furnitureObj.GetComponent<PlaceObj>().isPlaceTure)
        {
            placeObj.placeHelp.GetComponent<Rigidbody2D>().simulated = true;
            placeObj.placeHelp.GetComponent<SpriteRenderer>().color = Color.white;
        }
        else if (!furnitureObj.GetComponent<PlaceObj>().isPlaceTure)
        {
            placeObj.placeHelp.GetComponent<CaptureObject>().CaptureFinish(captureManager.inventoryIdx);
            if (captureManager.inventoryIdx != 5)
            {
                captureManager.inventoryIdx++;
            }
            else
            {
                captureManager.inventoryIdx = 0;
            }
            Destroy(placeObj.placeHelp);
        }

        placeObj.isPlaceStart = false;

        Destroy(furnitureObj);
        furnitureObj = null;
        image.raycastTarget = true;
    }
}
