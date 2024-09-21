using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public static class TextExpand
{
    public static void ChangeString(this TMP_Text parameter,bool isStart)
    {
        TextUpDownMove(parameter, isStart);
    }
}
