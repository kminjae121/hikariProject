using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public class ThirdStageTxt : MonoBehaviour
{
    private Sequence _textSequence;
    [SerializeField] private TextMeshProUGUI _text;

    private void Awake()
    {
    }

    private void Start()
    {
    }

    private void OnEnable()
    {
        PlayerChatBoxManager.Instance.Show("바이러스가 점프를 막았어!", 3, true)
            .Show("선풍기를 활용해 소파위를 올라가자!", 3.5f, true)
            .End();
    }

    private void Update()
    {
    }
}
