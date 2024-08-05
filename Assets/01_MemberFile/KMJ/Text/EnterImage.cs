using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class EnterImage : MonoBehaviour
{
    private Image _image;
    [SerializeField] private GameObject _panel;
    [SerializeField] private Vector2 _imageSize;
    [SerializeField] private LayerMask player;
    public List<Image> image = new List<Image>();
    [SerializeField] private TextMeshProUGUI tmp;
    [SerializeField] private TextMeshProUGUI tmpro;

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
        Collider2D hit = Physics2D.OverlapBox(transform.position, _imageSize, 0, player);

        
        if (hit == true && Input.GetMouseButtonUp(0))
        {
            tmpro.DOFade(0, 3);
            tmp.DOFade(0, 3);
            image.ForEach(f => f.DOFade(0, 3));
            StartCoroutine(Wait());
        }
    }


    
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3.3f);
        image.ForEach(image => image.DOKill(true));
        tmpro.DOKill(true);
        tmp.DOKill(true);
        yield return new WaitForSeconds(0.3f);
        _panel.SetActive(false);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, _imageSize);
        Gizmos.color = Color.white;
    }
}
