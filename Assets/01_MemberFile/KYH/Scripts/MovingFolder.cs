using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class MovingFolder : MonoBehaviour
{
    private Vector3 _mousePos;
    private bool _isHeld = false;

    [SerializeField]
    private GameObject holdObject;

    [SerializeField]
    private GameObject settingObject;
    [SerializeField]
    private CinemachineVirtualCamera settingCamera;

    [SerializeField]
    private Vector2 boxSize;
    [SerializeField]
    private LayerMask whatIsPutStation;

    public LayerMask whatIsApp;
    public LayerMask whatIsPlayer;

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
        RaycastHit2D hit = Physics2D.Raycast(_mousePos, Vector2.zero, 0, whatIsApp);

        if (hit)
        {
            print(hit.collider.name);
            if (hit.collider.CompareTag("Application") && Input.GetMouseButtonDown(0))
            {
                holdObject = hit.collider.gameObject;
                holdObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                _isHeld = true;
            }
        }
    }

    private void HoldObject()
    {
        holdObject.transform.position = Vector3.Lerp(holdObject.transform.position, _mousePos, 10f * Time.deltaTime);
        Collider2D putStation = Physics2D.OverlapBox(holdObject.transform.position, boxSize, 0, whatIsPutStation); // 슬롯
        Collider2D player = Physics2D.OverlapBox(holdObject.transform.position, boxSize, 0, whatIsPlayer); // 플레이어

        if (Input.GetMouseButtonUp(0))
        {
            if (player)
            {
                    print("플레이어");
            }
            else if ((putStation.gameObject.transform.childCount < 1 && putStation.CompareTag("Slot")))
            {
                holdObject.transform.SetParent(putStation.transform);
            }
            else
            {
                holdObject.transform.localPosition = Vector2.zero;
            }
            //_holdObject.transform.position = _holdObject.transform.root.position;
            _isHeld = false;
            holdObject.transform.localPosition = Vector2.zero;
            holdObject = null;
        }

    }

    void OnDrawGizmos()
    {
        if (holdObject == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(holdObject.transform.position, boxSize);
        Gizmos.color = Color.white;
        /*
        Gizmos.DrawWireSphere(transform.position, 4f);*/
    }
}
