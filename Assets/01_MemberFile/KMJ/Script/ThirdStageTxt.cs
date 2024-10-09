using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public class ThirdStageTxt : MonoBehaviour
{
    public  bool _isStart;
    private Sequence _textSequence;
    [SerializeField] private TextMeshProUGUI _txt;

    private void Awake()
    {
        _isStart = false;
    }

    private void Start()
    {
        _txt.TextUpDownMove(5, Color.red, 2.5f, TextStyle.Moving | TextStyle.UI | TextStyle.FadeIn);
        StartCoroutine(WaitEndText());
    }

    IEnumerator WaitEndText()
    {
        yield return new WaitForSeconds(8);
        _txt.enabled = false;
    }


}
