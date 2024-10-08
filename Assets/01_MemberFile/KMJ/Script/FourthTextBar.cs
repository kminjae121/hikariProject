using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FourthTextBar : MonoBehaviour
{
    public static bool _isStart;
    private void OnEnable()
    {
        PlayerChatBoxManager.Instance.Show("이번엔 바이러스가 와이파이 제어를 막았어!", 3, true)
            .Show("와이파이가 꺼지기전에 빨리 올라가자!", 3.5f, true)
            .End();
    }
    private void Awake()
    {
        _isStart = false;
    }

    private void Update()
    {
    }
}
