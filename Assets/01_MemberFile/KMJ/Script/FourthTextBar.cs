using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FourthTextBar : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _txt;

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
