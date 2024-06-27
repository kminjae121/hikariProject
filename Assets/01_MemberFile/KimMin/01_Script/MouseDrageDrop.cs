using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class MouseDrageDrop : MonoBehaviour
{
    [SerializeField]
    private GameObject riggingPlayer, playerSprite;

    private LayerMask defalt;

    public UnityEvent mouseTrigger;
    public UnityEvent mouseNotTrigger;
    private Vector3 _mousePos;
    private Vector2 _holdObjectVelocity , lastPos;

    private GameObject _holdObject;
    private bool _isHeld = false;

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
            if (hit.collider.CompareTag("ProgramIcon"))
            {
                mouseTrigger?.Invoke();
            }
            else
            {
                mouseNotTrigger.Invoke();
            }
            if (hit.collider.CompareTag("Player") && Input.GetMouseButton(0))
            {
                _holdObject = hit.collider.gameObject;
                //_holdObject.GetComponent<Rigidbody2D>().simulated = false; ¹Î

                _holdObject.GetComponent<Rigidbody2D>().gravityScale = 0f;
                _holdObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

                riggingPlayer.SetActive(true);
                //Rigidbody2D[] tr = riggingPlayer.GetComponentsInChildren<Rigidbody2D>();
                //foreach (var i in tr)
                //{
                //    i.GetComponent<Rigidbody2D>().gravityScale = 0f;
                //}
                _isHeld =   true;
                playerSprite.SetActive(false);
            }
        }
    }

    private void HoldObject()
    {/*
        _holdObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;*/
        _holdObject.transform.position = Vector3.Lerp(_holdObject.transform.position, _mousePos, 10f * Time.deltaTime);

        //RotateHoldObject();
        if (Input.GetMouseButtonUp(0))
        {
            Rigidbody2D rigid = _holdObject.GetComponent<Rigidbody2D>();

            _isHeld = false;
            rigid.gravityScale = 1f;
            rigid.velocity = Vector2.zero;
            rigid.gravityScale = 9.8f;

            //Rigidbody2D[] tr = riggingPlayer.GetComponentsInChildren<Rigidbody2D>();
            //foreach (var i in tr)
            //{
            //       i.GetComponent<Rigidbody2D>().gravityScale = 9.8f;
            //       i.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            //}
            Rigidbody2D[] tr = riggingPlayer.GetComponentsInChildren<Rigidbody2D>();
            foreach (var i in tr)
            {
                i.gameObject.transform.localPosition = new Vector3(0, 0, 0);
                i.velocity = Vector2.zero;
            }
            riggingPlayer.SetActive(false);
            playerSprite.SetActive(true);
            _holdObject.transform.localRotation = Quaternion.Euler(0, 0,0);
        }
    }

    private void RotateHoldObject()
    {
        float speed = _holdObject.transform.position.x - lastPos.x;

        _holdObject.transform.localRotation = Quaternion.Euler(0, 0, -speed * 50);
        lastPos = _holdObject.transform.position;
    }
}
