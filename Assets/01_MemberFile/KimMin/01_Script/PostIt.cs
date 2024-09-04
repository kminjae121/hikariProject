using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class PostIt : MonoBehaviour
{
    public static PostIt Instance;

    public Sprite[] _sprites;
    public GameObject _postItPrefab;
    public RectTransform _attachPos;
    public GameObject _canvas;

    public List<string> textList;

    public bool isAttached;

    public TMP_Text _text;

    [HideInInspector]  public GameObject _postIt;
    [HideInInspector]  public Image _image;
    [HideInInspector]  public Sequence seq;

    private void Awake()
    {
        if(gameObject != null)
        {
            Destroy(gameObject);
        }
        Instance = this;

        DontDestroyOnLoad(this);
        seq = DOTween.Sequence();
    }

    private void Initialize(Image image)
    {
        int rand = Random.Range(0, _sprites.Length);
        image.sprite = _sprites[rand];
    }

    public void Attach(int index)
    {
        _postIt = Instantiate
            (_postItPrefab, _attachPos.position, Quaternion.identity, _canvas.transform);

        _image = _postIt.GetComponent<Image>();

        Initialize(_image);

        _text = _postIt.GetComponentInChildren<TMP_Text>();
        _text.text = textList[index];

        isAttached = true;

        seq.Append(_image.DOFade(1, 0.1f))
            .Join(_image.transform.DOScale(1, 0.25f))
            .SetEase(Ease.InExpo);
    }

    public void Detach()
    {
        if (!isAttached)
            return;

        seq.Append(_image.DOFade(0, 0.15f))
            .Join(_image.transform.DOScale(3f, 0.4f))
            .SetEase(Ease.InExpo);

        Destroy(_text.gameObject);
        StartCoroutine(DtachCoroutine());
    }

    private IEnumerator DtachCoroutine()
    {
        yield return new WaitForSeconds(0.2f);
        Destroy(_image.gameObject);
    }
}
