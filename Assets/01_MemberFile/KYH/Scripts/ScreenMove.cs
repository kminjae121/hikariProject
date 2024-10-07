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

    public IApp app;
    private bool isInApp;

    private void Start()
    {
        DOYMove();
    }

    private void Update()
    {
        if(isInApp && Input.GetKeyDown(KeyCode.Escape))
        {
            if (app == IApp.Chrome)
                SceneManager.LoadScene("Setting");
            if (app == IApp.PowerPoint)
                print("ppt¿¬°á");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            isInApp =true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInApp = false;
        }
    }

    private void DOYMove()
    {
        gameObject.GetComponent<RectTransform>().DOLocalMoveY(yMoveInstance, 1).SetLoops(-1, LoopType.Yoyo).SetEase(ease);
    }
}
