using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FalseCaptureManager : MonoBehaviour
{
    private PlayerAnimation _playerAnimator;
    private PlayerMove _playerMove;
    private GameObject _captureManger;
    private GameObject _captrueUI;
    [SerializeField] private GameObject _EscParent;
    [SerializeField] private GameObject _Esc;
    [SerializeField] private Button GallyButton;

    private void Awake()
    {
        _playerAnimator = GameObject.Find("PlayerAnimation").GetComponent<PlayerAnimation>();
        _playerMove = GameObject.Find("PlayerPrefab").GetComponent<PlayerMove>();
        _captureManger = GameObject.Find("CaptureManager");
        _captrueUI = GameObject.Find("CapureClose");
    }

    public void CloseCaptureManger()
    {
        _playerAnimator._isAnimator = true;
        _playerMove._isForce = false;
        GallyButton.interactable = true;
        _Esc.SetActive(false);
        _EscParent.SetActive(true);
        OpenControlPanel._isTrue = true;
        _captrueUI.SetActive(false);
        _captureManger.SetActive(false);
    }
}
