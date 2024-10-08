using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class EnterImage : MonoBehaviour
{
    private Image _image;
    [SerializeField] private GameObject _panel;
    [SerializeField] private Vector2 _imageSize;
    [SerializeField] private LayerMask whatIsPlayer;
    public List<Image> image = new List<Image>();
    [SerializeField] private TextMeshProUGUI tmp;
    [SerializeField] private TextMeshProUGUI tmpText;
    [SerializeField] private TextMeshProUGUI tmpro;
    [SerializeField]
    private HingeJoint2D playerJoint;

    [SerializeField]
    private GameObject playerRigging;
    [SerializeField]
    private GameObject playerAnimation;
    
    [SerializeField]
    private GameObject playerFake;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }
    private void Start()
    {
        
    }
    private void Update()
    {
        EnterPanel();
    }

    private void EnterPanel()
    {
        Collider2D hit = Physics2D.OverlapBox(transform.position, _imageSize, 0, whatIsPlayer);

        
        if (hit == true && Input.GetMouseButtonUp(0))
        {
            playerAnimation.SetActive(false);
            playerRigging.SetActive(true);
            playerRigging.transform.root.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0f;
            playerJoint.useLimits = false;
            playerJoint.useMotor = true;
            StartCoroutine(Wait());
        }
    }


    
    IEnumerator Wait()
    {
        playerRigging.transform.root.gameObject.GetComponent<Transform>().DOScale(new Vector3(0,0,0),1.2f);
        yield return new WaitForSeconds(0.5f);
        //tmpro.DOFade(0, 3);
        //tmpText.DOFade(0, 3);
        //tmp.DOFade(0, 3);
        //image.ForEach(f => f.DOFade(0, 3));
        yield return new WaitForSeconds(3.3f);
        SceneManager.LoadScene("KimMin");
        //image.ForEach(image => image.DOKill(true));
        //tmpro.DOKill(true);
        //tmp.DOKill(true);
        //yield return new WaitForSeconds(0.3f);
        //_panel.SetActive(false);
        //playerFake.GetComponent<Rigidbody2D>().gravityScale = 9.8f;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, _imageSize);
        Gizmos.color = Color.white;
    }
}
