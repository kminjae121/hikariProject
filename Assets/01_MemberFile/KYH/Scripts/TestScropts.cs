using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScropts : MonoBehaviour
{
    private void Start()
    {
        PlayerChatBoxManager.Instance
            .Show("1번째 텍스트", 3f,true)
            .Show("2번째 텍스트입니다!!!!!!!!", 3f,true)
            .Show("4번째 텍스트입니다!!!!!!!!", 3f, true)
            .Show("5번째 텍스트입니다!!!!!!!!", 3f, true)
            .Show("6번째 텍스트입니다!!!!!!!!", 3f, true)
            .Show("7번째 텍스트입니다!!!!!!!!", 3f, true)
            .End();
    }
}
