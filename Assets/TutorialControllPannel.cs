using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TutorialControllPannel : MonoBehaviour
{
    [SerializeField] private GameObject[] _panels;
    [SerializeField] private GameObject[] tutorial;
    private GameObject _currentPanel;

    [SerializeField]
    private GameObject tutorialText;

    [SerializeField]
    private Button[] button;
    private int currentButton;

    [SerializeField]
    private Button goBackButton;

    public void OnPanelClick()
    {
        int index = int.Parse(EventSystem.current.currentSelectedGameObject.name.Substring(0, 1));
        _currentPanel = _panels[index - 1];
        tutorial[index-1].SetActive(true);

        if (_currentPanel != null)
            _currentPanel.SetActive(true);
        tutorialText.SetActive(false);
        goBackButton.interactable = true;
    }

    public void OnGoBackClick()
    {
        if (_currentPanel != null)
            _currentPanel.SetActive(false);
        goBackButton.interactable = false;
        tutorialText.SetActive(false);
    }

    public void OnCloseClick()
    {
        OpenControlPanel._isTrue = true;
        gameObject.SetActive(false);
    }


    public void ButtonTutorial()
    {
        currentButton++;

        for (int i = 0; i < button.Length; i++)
        {
            if (!(currentButton == 6 || currentButton == 5))
            {
                if (currentButton != int.Parse(button[i].name.Substring(0, 1)))
                    button[i].interactable = false;
                else
                    button[i].interactable = true;
            }
            else
            {
                for (int j = 0; j < button.Length; j++)
                {
                    if (!(j == 4 || j == 5))
                        button[j].interactable = true;
                }
            }
        }
    }
}
