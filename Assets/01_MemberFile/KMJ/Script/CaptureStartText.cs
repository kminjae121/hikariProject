using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class CaptureStartText : MonoBehaviour
{
    private Sequence _textSequence;
    [SerializeField] private Text _text;
    [SerializeField] private GameObject _textMember;

    private void Awake()
    {
        _textSequence = DOTween.Sequence()
            .Append(_text.DOText("Esc에 있는 캡쳐를 이용해", 2.3f))
            .AppendInterval(1f)
            .Append(_text.DOText("", 1))
            .Append(_text.DOText("물건을 캡쳐해서", 1.7f))
            .AppendInterval(1f)
            .Append(_text.DOText("", 1))
            .Append(_text.DOText("문을 향해 이동하세요", 2))
            .AppendInterval(1f)
            .Append(_text.DOText("", 1))
            .Append(_text.DOText("문에서 F키를 누르시면", 2))
            .AppendInterval(1f)
            .Append(_text.DOText("", 1))
            .Append(_text.DOText("다음스테이지로 넘어갑니다", 2.5f))
            .Append(_text.DOFade(0, 3));
    }

    private void Start()
    {
        _textSequence.Play();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            _textMember.SetActive(false);
    }


}
