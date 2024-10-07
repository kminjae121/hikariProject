using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class EnterCapture : MonoBehaviour
{
    [SerializeField] private GameObject _captureManager;
    [SerializeField] private GameObject _captureUI;
    [SerializeField] private GameObject _Esc;
    [SerializeField] private GameObject _EscParent;
    [SerializeField] private Button GallyButton;
    private Button _captureButton;
    private string currentSceneName;

    private void Awake()
    {
        _captureButton = GetComponent<Button>();
        _captureManager.SetActive(false);
    }

    private void Start()
    {
        currentSceneName = SceneManager.GetActiveScene().name;
    }

    private void Update()
    {
        TrueCapture();
    }

    private void TrueCapture()
    {
        if (currentSceneName == "CaptureStage")
            _captureButton.interactable = true;
        else
            _captureButton.interactable = false;
    }

    private void OnEnable()
    {
        GallyButton.interactable = false;
        _EscParent.SetActive(false);
        gameObject.SetActive(false);
        _Esc.SetActive(false);
        _captureManager.SetActive(true);
        _captureUI.SetActive(true);
    }
}
