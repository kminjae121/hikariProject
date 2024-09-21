using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextMove : MonoBehaviour
{
    public TMP_Text tMP;

    public void Start()
    {
        tMP.TextUpDownMove(3f);
    }
}
