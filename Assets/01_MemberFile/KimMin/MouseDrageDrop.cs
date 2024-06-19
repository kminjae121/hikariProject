using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDrageDrop : MonoBehaviour
{
    private Vector3 _mousePos;
    private Vector2 _lastPos;

    private GameObject _holdObject;
    private bool _isHeld = false;

    [SerializeField] private float _rotationScale;

    private void Update()
    {
        MousePosRay();

        if (_isHeld)
        {
            HoldObject();
        }
    }

    private void MousePosRay()
    {
        _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _mousePos.z = 0;
        RaycastHit2D hit = Physics2D.Raycast(_mousePos, Vector2.zero, Mathf.Infinity);

        if (hit)
        {
            if (hit.collider.CompareTag("Player") && Input.GetMouseButton(0))
            {
                _holdObject = hit.collider.gameObject;
                _holdObject.GetComponent<Rigidbody2D>().simulated = false;
                _isHeld = true;
            }
        }
    }

    private void HoldObject()
    {
        _holdObject.transform.position = Vector3.Lerp(_holdObject.transform.position, _mousePos, 10f * Time.deltaTime);

        RotateHoldObject();

        if (Input.GetMouseButtonUp(0))
        {
            Rigidbody2D rigid = _holdObject.GetComponent<Rigidbody2D>();

            _isHeld = false;
            rigid.simulated = true;
            rigid.velocity = Vector2.zero;
            _holdObject.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }

    private void RotateHoldObject()
    {
        float speed = _holdObject.transform.position.x - _lastPos.x;

        _holdObject.transform.localRotation = Quaternion.Euler(0, 0, -speed * _rotationScale);
        _lastPos = _holdObject.transform.position;
    }
}
