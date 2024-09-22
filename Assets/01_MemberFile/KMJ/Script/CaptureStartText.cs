using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class CaptureStartText : MonoBehaviour
{
    private Sequence _textSequence;
    [SerializeField] private Text _text;

    private void Awake()
    {
        _textSequence = DOTween.Sequence()
            .Append(_text.DOText("문을 향해 이동하세요", 4))
            .AppendInterval(1f)
            .Append(_text.DOText("", 1))
            .Append(_text.DOText("문에서 F키를 누르시면", 4))
            .AppendInterval(1f)
            .Append(_text.DOText("", 1))
            .Append(_text.DOText("다음스테이지로 넘어갑니다", 5))
            .Append(_text.DOFade(0, 3));
    }

    private void Start()
    {
        _textSequence.Play();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            _text.enabled = false;
    }


}
