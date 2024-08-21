using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class MovingFolder : MonoBehaviour
{
    private Vector3 _mousePos;
    private bool _isHeld = false;

    [SerializeField]
    private GameObject _holdObject;
    [SerializeField]
    private Vector2 boxSize;
    [SerializeField]
    private LayerMask whatIsPutStation;
    [SerializeField]
    private CinemachineVirtualCamera windowBackGroundCam;
    [SerializeField]
    private CinemachineVirtualCamera holdCam;

    void Update()
    {

        ClickFolder();
        if (_isHeld)
        {
            HoldObject();
        }
    }

    private void ClickFolder()
    {
        _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _mousePos.z = 0;
        RaycastHit2D hit = Physics2D.Raycast(_mousePos, Vector2.zero, Mathf.Infinity);

        if (hit)
        {
            print(hit.collider.name);
            if (hit.collider.CompareTag("Application") && Input.GetMouseButtonDown(0))
            {
                _holdObject = hit.collider.gameObject;
                _holdObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                _isHeld = true;
                _holdObject.transform.SetParent(null);
            }
        }
    }

    private void HoldObject()
    {

        _holdObject.transform.position = Vector3.Lerp(_holdObject.transform.position, _mousePos, 10f * Time.deltaTime);
        Collider2D putStation = Physics2D.OverlapBox(_holdObject.transform.position, boxSize, 0, whatIsPutStation);

        print(putStation.name);
        if (Input.GetMouseButtonUp(0))
        {
            if (putStation != null)
            {
                if (putStation.CompareTag("Player"))
                {

                }
                else if(putStation.CompareTag("Slot"))
                {
                    _holdObject.transform.SetParent(putStation.transform);
                }
            }
            //_holdObject.transform.position = _holdObject.transform.root.position;
            _isHeld = false;
            _holdObject.transform.localPosition = Vector2.zero;
            _holdObject = null;
        }

    }

    void OnDrawGizmos() // ���� �׸���
    {
        if (_holdObject == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(_holdObject.transform.position, boxSize);
        Gizmos.color = Color.white;
        /*
        Gizmos.DrawWireSphere(transform.position, 4f);*/
    }
}
