using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CaptureStartText : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private GameObject _textMember;

    private void Awake()
    {
       
    }

    private void Start()
    {
        _text.TextUpDownMove(3f, 2.5f,TextStyle.Moving | TextStyle.UI | TextStyle.FadeIn);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            _textMember.SetActive(false);
    }


    

}
