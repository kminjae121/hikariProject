using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptureManager : MonoBehaviour
{
    [Header("Ä¸ÃÄ ¼³Á¤°ª")]
    [SerializeField]
    private Vector2 captureSize;
    [SerializeField]
    private LayerMask whatIsCaptureObj;

    private void Update()
    {
        Capture();
    }

    public void Capture()
    {
        Collider2D[] captureObject = Physics2D.OverlapBoxAll(gameObject.transform.position,captureSize,0,whatIsCaptureObj);

        if(captureObject != null)
        {
            for(int i=0; i<captureObject.Length; i++)
            {
                captureObject[i]?.GetComponent<CaptureObject>().CaptureFinish();
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawCube(gameObject.transform.position, captureSize);
    }
}
