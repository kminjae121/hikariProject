using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public class FinalText : MonoBehaviour
{
    public static bool _isStart;

    private void Awake()
    {
        _isStart = false;
    }

    private void OnEnable()
    {
        PlayerChatBoxManager.Instance.Show("바이러스가 꺼졌어", 3, true)
           .Show("이제 마지막이야 빨리 탈출하자!", 3.5f, true)
           .End();
    }

    private void Update()
    {
    }
}
