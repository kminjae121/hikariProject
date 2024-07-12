using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonClick : MonoBehaviour
{
    [field: SerializeField] public TMP_InputField InputField { get; set; }

    public void Button1()
    {
        InputField.text = "심해속 탐험";
    }
    public void Button2()
    {
        InputField.text = "심해에 있는 물고기";
    }
    public void Button3()
    {
        InputField.text = "심해속 생물";
    }


}
