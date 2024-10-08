using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public class FinalText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _txt;

    

    private void Start()
    {
        _txt.TextUpDownMove(5, Color.green, 2.5f, TextStyle.Moving | TextStyle.UI | TextStyle.FadeIn);
        StartCoroutine(WaitEndText());
    }

    IEnumerator WaitEndText()
    {
        yield return new WaitForSeconds(8);
        _txt.enabled = false;
    }
}
