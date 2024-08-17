using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptureManager : MonoBehaviour
{
    [Header("캡쳐 설정값")]
    [SerializeField]
    private Vector2 captureSize;
    [SerializeField]
    private LayerMask whatIsCaptureObj;

    private Vector2 mousePos;
    private bool isNowCapture;

    public int inventoryIdx;

    private void Update()
    {
        Capture();
        MouseFollow();
    }

    private void MouseFollow()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (!isNowCapture)
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, mousePos, 10f * Time.deltaTime);
    }

    public void Capture()
    {
        Collider2D[] captureObject = Physics2D.OverlapBoxAll(gameObject.transform.position,captureSize,0,whatIsCaptureObj);

        if(Input.GetMouseButtonDown(0) && !isNowCapture)
        {
            if(captureObject != null)
            {
                isNowCapture = true;
                SaveInventory(captureObject);
                StartCoroutine(WaitCaptureRoutine());
            }
            print("캡쳐할 물cprk djqttmq니다");
            isNowCapture = false;
        }
    }

    private void SaveInventory(Collider2D[] captureObject)
    {
        for (int i = 0; i < captureObject.Length; i++)
        {
            if (inventoryIdx != 5)
            {
                captureObject[i].GetComponent<CaptureObject>().CaptureFinish(inventoryIdx);
                inventoryIdx++;
            }
            else
            {
                inventoryIdx = 0;
                captureObject[i].GetComponent<CaptureObject>().CaptureFinish(inventoryIdx);
            }
        }
    }

    private IEnumerator WaitCaptureRoutine()
    {
        yield return new WaitForSeconds(2f);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawCube(gameObject.transform.position, captureSize);
    }
}
