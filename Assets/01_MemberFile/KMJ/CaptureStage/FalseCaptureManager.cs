using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FalseCaptureManager : MonoBehaviour
{
    private GameObject _captureManger;
    private GameObject _captrueUI;
    [SerializeField] private GameObject _EscParent;
    [SerializeField] private GameObject _Esc;
    [SerializeField] private Button GallyButton;

    private void Awake()
    {
        _captureManger = GameObject.Find("CaptureManager");
        _captrueUI = GameObject.Find("CapureClose");
    }

    public void CloseCaptureManger()
    {
        GallyButton.interactable = true;
        _Esc.SetActive(false);
        _EscParent.SetActive(true);
        OpenControlPanel._isTrue = true;
        _captrueUI.SetActive(false);
        _captureManger.SetActive(false);
    }
}
