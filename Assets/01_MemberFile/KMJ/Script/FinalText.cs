using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class FinalText : MonoBehaviour
{
        private Sequence _textSequence;
        [SerializeField] private Text _text;
        [SerializeField] private GameObject _textMember;

        private void Awake()
        {
            _textSequence = DOTween.Sequence()
                .Append(_text.DOText("바이러스가 해제 되었습니다",2.3f))
                .AppendInterval(1f)
                .Append(_text.DOText("", 1))
                .Append(_text.DOText("이제 점프를 사용하실 수 있습니다.", 2.5f))
                .AppendInterval(1f)
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
