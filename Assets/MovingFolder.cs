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
    private LayerMask whatIsPlayer;
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
            if (hit.collider.CompareTag("Application") && Input.GetMouseButtonDown(0))
            {
                _holdObject = hit.collider.gameObject;
                _holdObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                _isHeld = true;
            }
        }
    }

    private void HoldObject()
    {/*
        _holdObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;*/
        _holdObject.transform.position = Vector3.Lerp(_holdObject.transform.position, _mousePos, 10f * Time.deltaTime);
        Collider2D[] TriggerPlayer = Physics2D.OverlapBoxAll(_holdObject.transform.position, boxSize, 0, whatIsPlayer);

        if (Input.GetMouseButtonUp(0))
        {
            if (TriggerPlayer.Length != 0)
            {
                //holdCam
            }
            _holdObject.transform.position = _holdObject.transform.root.position;
            _isHeld = false;
        }

    }

    void OnDrawGizmos() // ���� �׸���
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(_holdObject.transform.position, boxSize);/*
        Gizmos.DrawWireSphere(transform.position, 4f);*/
    }
}
