using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupPrefab : MonoBehaviour
{
    public bool canDrag;

    private GameObject popUp;

    public LayerMask wahtIsPopup;
    private Vector2 mousePos;


    private void Update()
    {
        if (canDrag)
        {
            FollowMouse();
        }
    }

    public void DragChecker(Collider2D collider)
    {
        popUp = collider.gameObject;
        canDrag = true;
    }

    private void FollowMouse()
    {
        popUp.transform.position = Vector3.Lerp(popUp.transform.position, UtillClass.GetMousePointerPosition(), Time.deltaTime * 10);

        if (Input.GetMouseButtonUp(0))
        {
            canDrag = false;
            popUp = null;
        }
    }
}
