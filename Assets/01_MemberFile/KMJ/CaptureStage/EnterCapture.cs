using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterCapture : MonoBehaviour
{
    [SerializeField] private GameObject _captureManager;
    [SerializeField] private GameObject _captureUI;
    [SerializeField] private GameObject _Esc;
    [SerializeField] private GameObject _EscParent;

    private void Awake()
    {
        _captureManager.SetActive(false);
    }
    private void OnEnable()
    {
        _EscParent.SetActive(false);
        gameObject.SetActive(false);
        _Esc.SetActive(false);
        _captureManager.SetActive(true);
        _captureUI.SetActive(true);
    }
}
