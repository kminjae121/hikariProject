using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class PostIt : MonoBehaviour
{
    [SerializeField] private Sprite[] _sprites;
    [SerializeField] private GameObject _postItPrefab;
    [SerializeField] private RectTransform _attachPos;

    [SerializeField] private List<string> textList;

    private bool isAttached;

    private TMP_Text _text;

    private Transform _canvas;
    private GameObject _postIt;
    private Image _image;
    private Sequence seq;

    private void Awake()
    {
        _canvas = GameObject.Find("Canvas").transform;
        seq = DOTween.Sequence();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Attach(2);
        }
        
        if (Input.GetKeyDown(KeyCode.F))
        {
            Detach();
        }
    }

    private void Initialize(Image image)
    {
        int rand = Random.Range(0, _sprites.Length);
        image.sprite = _sprites[rand];
    }

    private void Attach(int index)
    {
        _postIt = Instantiate
            (_postItPrefab, _attachPos.position, Quaternion.identity, _canvas);

        _image = _postIt.GetComponent<Image>();

        Initialize(_image);

        _text = _postIt.GetComponentInChildren<TMP_Text>();
        _text.text = textList[index];

        isAttached = true;

        seq.Append(_image.DOFade(1, 0.1f))
            .Join(_image.transform.DOScale(1, 0.25f))
            .SetEase(Ease.InExpo);
    }

    private void Detach()
    {
        if (!isAttached)
            return;

        seq.Append(_image.DOFade(0, 0.15f))
            .Join(_image.transform.DOScale(3f, 0.4f))
            .SetEase(Ease.InExpo);

        Destroy(_text.gameObject);
        StartCoroutine(DtachCoroutine());
    }

    IEnumerator DtachCoroutine()
    {
        yield return new WaitForSeconds(0.2f);
        Destroy(_image.gameObject);
    }
}
