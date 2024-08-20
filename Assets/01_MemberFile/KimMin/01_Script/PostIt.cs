using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PostIt : MonoBehaviour
{
    [SerializeField] private Sprite[] _sprites;
    [SerializeField] private GameObject _postItPrefab;
    [SerializeField] private RectTransform _attachPos;

    private bool isAttached;

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
            Attach();
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

    private void Attach()
    {
        _postIt = Instantiate
            (_postItPrefab, _attachPos.position, Quaternion.identity, _canvas);

        _image = _postIt.GetComponent<Image>();
        Initialize(_image);

        isAttached = true;

        seq.Append(_image.DOFade(1, 0.1f))
            .Join(_image.transform.DOScale(2.5f, 0.15f))
            .Append(_image.transform.DOScale(1f, 0.4f))
            .SetEase(Ease.OutExpo);
    }

    private void Detach()
    {
        if (!isAttached)
            return;

        seq.Append(_image.DOFade(0, 0.15f))
            .Join(_image.transform.DOScale(3f, 0.4f))
            .SetEase(Ease.OutExpo)
            .OnComplete(() =>
            {
                Destroy(_postIt);
            });
    }
}
