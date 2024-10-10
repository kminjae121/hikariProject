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
    public bool isDisableOnButton;

    [SerializeField]
    private GameObject gameScriptManager;
    [SerializeField]
    private GameObject gameAppScreen;
    [SerializeField]
    private AppDescription appDescription;

    [SerializeField]
    private MouseDrageDrop mouseDrageDrop;

    private void Awake()
    {
            playerAnimator = GameObject.Find("PlayerAnimation").GetComponent<Animator>();
            GameManager.Instance.OnClickDown += ClickFolderInvoke;
    }

    private void Start()
    {
        if (!GameManager.Instance.isClearSea && !GameManager.Instance.isCapture && !GameManager.Instance.isFinishIntro)
            playerAnimator.gameObject.SetActive(false);
        else
            playerAnimator.gameObject.transform.root.position = new Vector3(0,10,0);

    }

    private void Update()
    {
        if (_isHeld && settingButton.holdObject != null && !isSettingPanelChoose)
            HoldObject();
    }

    public void ClickFolderInvoke()
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

        if (hit && !QuestPopUp.isQuestHold)
        {
            if(hit.CompareTag("PopUp"))
            {
                hit.GetComponent<PopupPrefab>().DragChecker(hit);
            }
            else if (hit.CompareTag("Lock"))
            {
                hit.gameObject.GetComponent<LockfadeIn>().LockFade();
            }
            else if (hit.CompareTag("Application") && GameManager.Instance.isFinishTutorial)
            {
                settingButton.holdObject = hit.gameObject;
                settingButton.holdObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                _isHeld = true;
            }
            else if(hit.name == "OnButton(UsingNameIn<FolderManager>)" && isDisableOnButton == false)
            {
                print("누름");
                GameObject.Find("OnButton(UsingNameIn<FolderManager>)").GetComponent<OnButton>().ActiveSettingPanel();
            }
            else if (hit.CompareTag("Player") && GameManager.Instance.isFinishTutorial)
            {
                print(mouseDrageDrop);
                mouseDrageDrop.MousePosRay(hit);
            }
        }
    }

    private void HoldObject()
    {
        Collider2D player = null;
        Collider2D putStation = null;
        putStation = Physics2D.OverlapBox(settingButton.holdObject.transform.position, boxSize, 0, whatIsPutStation); // 슬롯
        player = Physics2D.OverlapBox(settingButton.holdObject.transform.position, boxSize, 0, whatIsPlayer); // 플레이어

        App holdApp = settingButton.holdObject.GetComponent<MovingFolder>().thisObjectIsWhat;

        settingButton.holdObject.transform.position = Vector3.Lerp(settingButton.holdObject.transform.position, UtillClass.GetMousePointerPosition(), 10f * Time.deltaTime);

        if (Input.GetMouseButtonUp(0))
        {
            if(!putStation)
            {
                _isHeld = false;
                settingButton.holdObject.transform.localPosition = Vector2.zero;
            }
            else
            {
                if (player && putStation)
                {
                    settingCamera.Priority = 2;
                    settingButton.holdObject.transform.SetParent(usingApp);
                    settingButton.holdObject.transform.localPosition = Vector2.zero;
                    settingButton.gameObject.SetActive(true);
                    isSettingPanelChoose = true;
                    returnPos = putStation;
                    settingButton.currentAPP = holdApp;
                    appDescription.currentAPP = holdApp;
                    gameAppScreen.SetActive(false);
                    gameScriptManager.SetActive(false);

                    playerAnimator.SetBool("Hold", true);
                    return;
                }
                else if ((putStation.gameObject.transform.childCount < 1 && putStation.CompareTag("Slot")))
                {
                    settingButton.holdObject.transform.SetParent(putStation.transform);
                }
            }
            EndHold();
        }

    }

    private void EndHold()
    {
        _isHeld = false;
        settingButton.holdObject.transform.localPosition = Vector2.zero;

    }

    void OnDrawGizmos()
    {
        if (settingButton.holdObject == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(settingButton.holdObject.transform.position, boxSize);
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
