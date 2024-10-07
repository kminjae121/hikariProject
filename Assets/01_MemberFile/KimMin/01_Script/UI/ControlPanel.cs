using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ControlPannel : MonoBehaviour
{
    [SerializeField] private GameObject[] _panels;
    private GameObject _currentPanel;
    private PlayerAnimation _playerAnimator;
    private PlayerMove _playerMove;

    private void Awake()
    {
        _playerAnimator = GameObject.Find("PlayerAnimation").GetComponent<PlayerAnimation>();
        _playerMove = GameObject.Find("PlayerPrefab").GetComponent<PlayerMove>();
    }

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
        _playerAnimator._isAnimator = true;
        _playerMove._isForce = false;
        OpenControlPanel._isTrue = true;
        gameObject.SetActive(false);
    }
}
