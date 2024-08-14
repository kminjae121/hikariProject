using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EnterName : MonoBehaviour
{
    public TextMeshProUGUI receiveText;
    public TMP_InputField display;

    public List<string> str = new List<string>();

    

    private void Start()
    {
        receiveText.text = PlayerPrefs.GetString("이름 입력");
    }

    public void Enter()
    {
        if(display.text.Length < 5)
        {
            receiveText.text = $"사용자이름: {display.text}";
        }
        else
        {
            receiveText.text = $"다시 입력하세요";
        }
        PlayerPrefs.SetString("이름 입력",  receiveText.text);
        PlayerPrefs.Save();
        
    }


    private void Update()
    {
        None();
        Filtering();
    }

    private void Filtering()
    {
        foreach (string no in str)
        {
            if(display.text == no)
            {
                receiveText.text = "부적절한 이름입니다";
            }
        }
    }

    private void None()
    {
        if(Input.GetMouseButtonDown(1))
        {
            receiveText.text = $"사용자이름: 히카리여";
        }
    }
}
