using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenControlPanel : MonoBehaviour
{
    [SerializeField] private GameObject _controlPanel;
    public static bool _isTrue;


    private void Awake()
    {
        _isTrue = true;
    }

    private void Start()
    {
        _isTrue = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && _isTrue == true)
        {
            _isTrue = false;
            _controlPanel.SetActive(true);
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && _isTrue == false)
        {
            _isTrue = true;
            _controlPanel.SetActive(false);
        }
    }
}
