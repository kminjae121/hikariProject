using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FalseCaptureManager : MonoBehaviour
{
    private GameObject _captureManger;
    private GameObject _captrueUI;
    [SerializeField] private GameObject _EscParent;
    [SerializeField] private GameObject _Esc;

    private void Awake()
    {
        _captureManger = GameObject.Find("CaptureManager");
        _captrueUI = GameObject.Find("CapureClose");
    }

    public void CloseCaptureManger()
    {
        _Esc.SetActive(false);
        _EscParent.SetActive(true);
        OpenControlPanel._isTrue = true;
        _captrueUI.SetActive(false);
        _captureManger.SetActive(false);
    }
}
