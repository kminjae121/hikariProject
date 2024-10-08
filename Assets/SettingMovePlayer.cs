using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class SettingMovePlayer : MonoBehaviour
{
    [SerializeField]
    private GameObject riggingPlayer, playerSprite;

    private LayerMask defalt;
    private Vector3 _mousePos;
    private Vector2 _holdObjectVelocity, lastPos;
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

    public void MousePosRay()
    {
        _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _mousePos.z = 0;
        RaycastHit2D hit = Physics2D.Raycast(_mousePos, Vector2.zero, Mathf.Infinity);

        if (hit)
        {
            if (hit.collider.CompareTag("Player") && Input.GetMouseButtonDown(0))
            {
                _holdObject = hit.collider.gameObject;
                //_holdObject.GetComponent<Rigidbody2D>().simulated = false; �ξȳ��ϼ���

                _holdObject.GetComponent<Rigidbody2D>().gravityScale = 0f;
                _holdObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

                riggingPlayer.SetActive(true);
                //Rigidbody2D[] tr = riggingPlayer.GetComponentsInChildren<Rigidbody2D>();
                //foreach (var i in tr)
                //{
                //    i.GetComponent<Rigidbody2D>().gravityScale = 0f;
                //}
                _isHeld = true;
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
            _isHeld = false;

            Rigidbody2D rigid = _holdObject.GetComponent<Rigidbody2D>();

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
            _holdObject.transform.localRotation = Quaternion.Euler(0, 0, 0);

        }

    }
}
