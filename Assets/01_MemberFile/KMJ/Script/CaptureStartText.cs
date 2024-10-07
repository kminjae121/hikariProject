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
        PlayerChatBoxManager.Instance.Show("대저택이 무너졌어", 3, true)
            .Show("빨리 문으로 이동하여 탈출하자!", 3.5f, true)
            .End();
    }

    private void OnEnable()
    {   
    }

    private void Update()
    {
    }


    

}
