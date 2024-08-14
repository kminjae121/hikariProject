using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ButtonMnager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _currentText;
    [SerializeField] private Button _brightButton;

    public List<GameObject> ChangeButton = new List<GameObject>();
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
        int i = 0;
        switch(SceneNumber)
        {
            case 3:
                _currentText.text = "»çÀü";
                ChangeButton[i].SetActive(true);
                i++;
                break;
            case 4:
                _currentText.text = "Ä¸ÃÄ";
                ChangeButton[i - 1].SetActive(false);
                ChangeButton[i].SetActive(true);
                break;
            case 5:
                _currentText.text = null;
                break;
        }
    }

    private void InteractablFalse()
    {
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            _brightButton.interactable = true;
        }
        else
        {
            _brightButton.interactable = false;
        }
    }
}
