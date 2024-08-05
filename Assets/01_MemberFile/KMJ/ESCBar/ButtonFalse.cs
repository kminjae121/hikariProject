using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ButtonFalse : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _currentText;
    [SerializeField] private Button _brightButton;
    public int SceneNumber;

    private void Awake()
    {
        _brightButton.interactable = false;
    }

    private void Update()
    {
        SceneNumber = SceneManager.GetActiveScene().buildIndex;

        SceneTextChange();

        InteractablFalse();
    }

    private void SceneTextChange()
    {
        switch(SceneNumber)
        {
            case 3:
                _currentText.text = "»çÀü";
                break;
        }
    }

    private void InteractablFalse()
    {
        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            _brightButton.interactable = true;
        }
    }
}
