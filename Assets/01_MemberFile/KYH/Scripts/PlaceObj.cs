using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceObj : MonoBehaviour
{
    private PlaceObjSO placeObjSO;

    private Collider2D _player;
    private Collider2D _collider;
    private Vector2 mouseDir;
    
    
    public GameObject furniturePrefab { get; set; }
    public GameObject placeHelp = null;
    public bool isPlaceStart;
    public bool isPlaceTure;
    public LayerMask whatIsGround;

    private void Awake()
    {
        _player = GameObject.Find("PlayerPrefab").GetComponent<Collider2D>();
        _collider = GetComponent<Collider2D>();
    }



    private void FixedUpdate()
    {

        MousePos();
        if (isPlaceStart)
        {
            RaycastHit2D hit = Physics2D.BoxCast(
                origin: mouseDir,
                size: new Vector2(_collider.bounds.size.x, 1),
                angle: 0,
                direction: Vector2.down,
                distance : Mathf.Infinity
            );
            //print(hit.collider.name);

            placeHelp.transform.position = hit.point;//이거로 배치할 곳 띄우고 배치

            SpriteRenderer sp = placeHelp.GetComponent<SpriteRenderer>();

            LayerMask colliisionMask = 1 << hit.transform.gameObject.layer;

            if (hit.collider.CompareTag("CaptureObj") || hit.collider.CompareTag("Ground"))
            {
                if (gameObject.GetComponent<ObjectGather>() != null)
                    placeHelp.GetComponent<ObjectGather>().enabled = false;
                sp.color = Color.green;
                isPlaceTure = true;
            }
            else
            {
                sp.color = Color.red;
                isPlaceTure = false;
            }
        }
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(mouseDir, Vector2.down);
        Gizmos.color = Color.white;
    }
#endif

    /// <summary>
    /// 아잇응
    /// </summary>
    public void PlaceIt()
    {
        placeObjSO = GetComponent<CaptureObject>().captureSprite;
        furniturePrefab = placeObjSO.prefab;
        print("실행");
        placeHelp = Instantiate(furniturePrefab);
        placeHelp.GetComponent<Rigidbody2D>().simulated = false;

        if (gameObject.GetComponent<ObjectGather>() != null)
            placeHelp.GetComponent<ObjectGather>().enabled = false;
        isPlaceStart = true;
    }
    
    private void MousePos()
    {
        mouseDir = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
