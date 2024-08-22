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
        ClickPopup();
        
        if(canDrag)
            DragChecker();
    }

    private void ClickPopup()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero, 0, wahtIsPopup);

        if(hit)
        {
            if (Input.GetMouseButtonDown(0))
            {
                popUp = hit.collider.gameObject;
                canDrag = true;
            }
        }
    }

    private void DragChecker()
    {
        popUp.transform.position = Vector3.Lerp(popUp.transform.position,mousePos, Time.deltaTime * 10);
        
        if (Input.GetMouseButtonUp(0))
        {
            canDrag = false;
        }
    }
}
