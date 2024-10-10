using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public enum IApp
{
    Chrome,
    PowerPoint
}

public class ScreenMove : MonoBehaviour
{
    [SerializeField]
    private Ease ease;
    [SerializeField]
    private float yMoveInstance;

    [SerializeField]
    private GameObject pushEKey;

    public IApp app;

    [SerializeField]
    private bool isInApp;

    [SerializeField]
    private FolderManager folderManager;


    private void Start()
    {
        DOYMove();
    }

    private void Update()
    {
        if(isInApp && Input.GetKeyDown(KeyCode.E))
        {
            if (app == IApp.Chrome)
            {
                QuestPopupUI.Instance.QuestTxt();
                SoundManager.Instance.ChangeMainStageVolume("windowSceneBGM", true, ISOund.BGM);
                GameManager.Instance.OnClickDown -= folderManager.ClickFolderInvoke;
                SceneManager.LoadScene("Setting");
            }
            if (app == IApp.PowerPoint)
            {
                QuestPopupUI.Instance.QuestTxt();
                GameManager.Instance.OnClickDown -= folderManager.ClickFolderInvoke;
                SceneManager.LoadScene("CaptureStage");
                print("ppt¿¬°á");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInApp = true;
            pushEKey.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInApp = false;
            pushEKey.SetActive(false);
        }
    }

    private void DOYMove()
    {
        gameObject.GetComponent<RectTransform>().DOLocalMoveY(yMoveInstance, 1).SetLoops(-1, LoopType.Yoyo).SetEase(ease);
    }
}
