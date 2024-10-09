using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class CaptureStartText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _txt;
    private void Awake()
    {
       
    }


    private void Start()
    {
        _txt.TextUpDownMove(5, Color.black, 2.5f,TextStyle.Moving | TextStyle.UI | TextStyle.FadeIn);
        StartCoroutine(WaitEndText());
    }

    IEnumerator WaitEndText()
    {
        yield return new WaitForSeconds(8);
        _txt.enabled = false;
    }
}
