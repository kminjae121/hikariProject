using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public class SecondText : MonoBehaviour
{
    private Sequence _textSequence;
    [SerializeField] private TextMeshProUGUI _text;

    private void Awake()
    {
    }

    private void Start()
    {
        _text.TextUpDownMove(7f, Color.black, 2.4f, TextStyle.Moving | TextStyle.UI | TextStyle.FadeIn);
    }

    private void Update()
    {
    }
}
