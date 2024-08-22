using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupPrefab : MonoBehaviour
{
    public bool CanDrag;

    private GameObject Popup;

    private LayerMask 

    private void Update()
    {
        ClickPopup();
        DragChecker();
    }

    private void ClickPopup()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero, 0,);
    }

    private void DragChecker()
    {
        if ( Input.GetMouseButton(0) && CanDrag)
        {
            
        }

        if (Input.GetMouseButtonUp(0))
        {
            CanDrag = false;
            transform.position = transform.position;
        }
    }
}
