using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EnterName : MonoBehaviour
{
    public TextMeshProUGUI receiveText;
    public TMP_InputField display;

    private void Start()
    {
        receiveText.text = PlayerPrefs.GetString("이름 입력");
    }

    public void Enter()
    {
        receiveText.text = $"사용자이름: {display.text}";
        PlayerPrefs.SetString("이름 입력", receiveText.text);
        PlayerPrefs.Save();
    }


    private void Update()
    {
        None();
    }
    public void None()
    {
        if(Input.GetMouseButtonDown(1))
        {
            receiveText.text = $"사용자이름: 따따잇";
        }
    }
}
