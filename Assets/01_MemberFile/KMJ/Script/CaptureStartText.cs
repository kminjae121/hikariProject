using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class CaptureStartText : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private GameObject _textMember;
    private Color[] color;

    private void Awake()
    {
    }

    private void Start()
    {
        _text.TextUpDownMove(5f, Color.black, 2.4f,TextStyle.Moving | TextStyle.UI | TextStyle.FadeIn);
    }

    private void Update()
    {
        StartCoroutine(Wait());
    }

    
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(7);
        _textMember.SetActive(false);
    }

    

}
