using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class FolderManager : MonoBehaviour
{
    public LayerMask whatIsPutStation;
    public LayerMask whatIsPlayer;
    public LayerMask whatIsApp;

    [SerializeField]
    private CinemachineVirtualCamera settingCamera;

    private static bool isSettingPanelChoose;

    private bool _isHeld = false;

    public SettingButtonManager settingButton;

    [SerializeField]
    private Vector2 boxSize;


    private static Collider2D returnPos;

    [SerializeField]
    private bool isLock;
    [SerializeField]
    private float holdingRadius;

    private Animator playerAnimator;

    [SerializeField]
    private Transform usingApp;

    private void Awake()
    {
        playerAnimator = GameObject.Find("PlayerAnimation").GetComponent<Animator>();
    }

    private void Start()
    {
        playerAnimator.gameObject.SetActive(false);
        GameManager.Instance.OnClickDown += ClickFolderInvoke;
    }

    private void Update()
    {
        if (_isHeld && settingButton.holdObject != null && !isSettingPanelChoose)
            HoldObject();
    }

    private void ClickFolderInvoke()
    {
        if (isLock)
        {

        }
        else if (!isSettingPanelChoose)
        {
            ClickFolder();
        }
    }

    private void ClickFolder()
    {
        Collider2D hit = Physics2D.OverlapCircle(UtillClass.GetMousePointerPosition(), holdingRadius, whatIsApp);

        if (hit)
        {
            if (hit.CompareTag("Lock"))
            {
                print("ttqq");
                hit.gameObject.GetComponent<LockfadeIn>().LockFade();
            }
            else if (hit.CompareTag("Application"))
            {
                print("댐");
                settingButton.holdObject = hit.gameObject;
                settingButton.holdObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                _isHeld = true;
            }
            else if(hit.name == "OnButton(UsingNameIn<FolderManager>)")
            {
                GameObject.Find("OnButton(UsingNameIn<FolderManager>)").GetComponent<OnButton>().ActiveSettingPanel();
            }
        }
    }

    private void HoldObject()
    {
        print("실행중");
        Collider2D player = null;
        Collider2D putStation = null;

        App holdApp = settingButton.holdObject.GetComponent<MovingFolder>().thisObjectIsWhat;

        settingButton.holdObject.transform.position = Vector3.Lerp(settingButton.holdObject.transform.position, UtillClass.GetMousePointerPosition(), 10f * Time.deltaTime);
        putStation = Physics2D.OverlapBox(settingButton.holdObject.transform.position, boxSize, 0, whatIsPutStation); // 슬롯
        player = Physics2D.OverlapBox(settingButton.holdObject.transform.position, boxSize, 0, whatIsPlayer); // 플레이어

        if (Input.GetMouseButtonUp(0))
        {
            if (player)
            {
                settingCamera.Priority = 2;
                settingButton.holdObject.transform.SetParent(usingApp);
                settingButton.holdObject.transform.localPosition = Vector2.zero;
                settingButton.gameObject.SetActive(true);
                isSettingPanelChoose = true;
                returnPos = putStation;
                settingButton.currentAPP = holdApp;

                playerAnimator.SetBool("Hold", true);
                return;
            }
            else if ((putStation.gameObject.transform.childCount < 1 && putStation.CompareTag("Slot")))
            {
                settingButton.holdObject.transform.SetParent(putStation.transform);
            }
            EndHold();
        }

    }

    private void EndHold()
    {
        print("실행확인");
        _isHeld = false;
        settingButton.holdObject.transform.localPosition = Vector2.zero;
    }

    void OnDrawGizmos()
    {
        if (settingButton.holdObject == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(settingButton.holdObject.transform.position, boxSize);
        Gizmos.color = Color.white;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(UtillClass.GetMousePointerPosition(), holdingRadius);
        Gizmos.color = Color.white;
    }

    public void CancelButton()
    {
        if(settingButton.holdObject != null && settingButton.holdObject.GetComponent<MovingFolder>().thisObjectIsWhat == App.Chrome)
            WindowObj.Instance.popUpChrome.SetActive(false);
        playerAnimator.SetBool("Hold", false);
        isSettingPanelChoose = false;
        settingCamera.Priority = 0;
        settingButton.gameObject.SetActive(false);
        print(settingButton.holdObject);
        settingButton.holdObject.transform.SetParent(returnPos.transform);
        settingButton.holdObject.transform.localPosition = Vector2.zero;
        settingButton.holdObject = null;
    }
}
