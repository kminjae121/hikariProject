using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceObj : MonoBehaviour
{
    private PlaceObjSO placeObjSO;
    private PlaceObjListSO placeObjListSO;
    private Vector2 mouseDir;
    GameObject dd;

    private void Awake()
    {
        placeObjSO = placeObjListSO.placeObjSO[0];
    }

    private void Update()
    {
        mouseDir = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void Test()
    {
        RaycastHit2D hit = Physics2D.Raycast(mouseDir,Vector2.down,float.PositiveInfinity);

        if (hit.collider.tag == "Ground")
        {
            GameObject d = Instantiate(dd);
            d.transform.position = hit.point;
        }


    }
}
