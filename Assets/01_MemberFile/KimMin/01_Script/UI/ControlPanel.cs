using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ControlPannel : MonoBehaviour
{
    [SerializeField] private GameObject[] _panels;
    private GameObject _currentPanel;

    public void OnPanelClick()
    {
        int index = int.Parse(EventSystem.current.currentSelectedGameObject.name.Substring(0, 1));
        _currentPanel = _panels[index - 1]; 

        if (_currentPanel != null)
            _currentPanel.SetActive(true);
    }

    public void OnGoBackClick()
    {
        if (_currentPanel != null)
            _currentPanel.SetActive(false);
    }

    public void OnCloseClick()
    {
        OpenControlPanel._isTrue = true;
        gameObject.SetActive(false);
    }
}
