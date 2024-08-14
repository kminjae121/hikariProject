using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceObj : MonoBehaviour
{
    private PlaceObjSO placeObjSO;

    private Vector2 mouseDir;
    private GameObject furniturePrefab;
    public GameObject placeHelp = null;
    public bool isPlaceStart;
    public bool isPlaceTure;

    private void FixedUpdate()
    {
        MousePos();
        if (isPlaceStart)
        {
            RaycastHit2D hit = Physics2D.Raycast(mouseDir, Vector2.down, Mathf.Infinity);
            print(hit.collider.name);

            placeHelp.transform.position = hit.point;//이거로 배치할 곳 띄우고 배치

            SpriteRenderer sp = placeHelp.GetComponent<SpriteRenderer>();
            if (hit.collider.CompareTag("Ground") || hit.collider.CompareTag("CaptureObj"))
            {
                sp.color = Color.green;
                isPlaceTure = true;
            }
            else
            {
                sp.color = Color.red;
                isPlaceTure = false;
            }
        }
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(mouseDir, Vector2.down);
        Gizmos.color = Color.white;
    }
#endif

    /// <summary>
    /// 아잇응
    /// </summary>
    public void PlaceIt()
    {
        placeObjSO = GetComponent<CaptureObject>().captureSprite;
        furniturePrefab = placeObjSO.prefab;
        print("실행");
        placeHelp = Instantiate(furniturePrefab);
        placeHelp.GetComponent<Rigidbody2D>().simulated = false;
        isPlaceStart = true;
    }
    
    private void MousePos()
    {
        mouseDir = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
