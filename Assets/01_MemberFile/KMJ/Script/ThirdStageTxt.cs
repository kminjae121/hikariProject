using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public class ThirdStageTxt : MonoBehaviour
{
    public static bool _isStart;
    private Sequence _textSequence;
    [SerializeField] private TextMeshProUGUI _text;

    private void Awake()
    {
        _isStart = false;
    }

    private void Start()
    {
    }

    private void OnEnable()
    {
        PlayerChatBoxManager.Instance.Show("바이러스가 점프를 막았어!", 3, true)
                    .Show("내 바로 밑에 소파를 설치해서 위로 올라가자!", 3.5f, true)
                    .End();
    }

    private void Update()
    { 
    }
}
