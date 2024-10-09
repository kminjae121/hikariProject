using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class TextFadeDDD : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI text;
    void Start()
    {
        StartCoroutine(Roudad());
    }

    private IEnumerator Roudad()
    {
        yield return new WaitForSeconds(2f);
        text.DOFade(0, 1);
        yield return new WaitForSeconds(1f);
        text.gameObject.SetActive(false);
    }
}
