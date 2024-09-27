using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TestTextKYJ : MonoBehaviour
{
    public TMP_Text text;

    // Start is called before the first frame update
    void Start()
    {
        text.TextUpDownMove(5f,Color.white,2.5f,TextStyle.FadeIn);
    }

}
