using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DicionaryTrue : MonoBehaviour
{
    [SerializeField] private GameObject _dicionary;

    private bool _isOpen;

    private void Awake()
    {
        _isOpen = true;
    }
    public void ButtonClick()
    {
        if (_isOpen == true)
        {
            _dicionary.SetActive(true);
            _isOpen = false;
        }
        else if(_isOpen == false)
        {
            _dicionary.SetActive(false);
            _isOpen = true;
        }
    }
}
