using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

public class ButtonUI : MonoBehaviour
{
    private StartUI startUI;
    [SerializeField] private Image soundUI;

    private void Awake()
    {
        startUI = GetComponent<StartUI>();
    }

    public void StartBtn()
    {
        SceneManager.LoadScene("WindowScene");
    }

    public void QuitBtn()
    {
        Application.Quit();
    }

    public void SoundBtn()
    {
        startUI._menuObj.gameObject.SetActive(false);
        soundUI.GetComponent<RectTransform>().DOAnchorPosX(-400, 1);
    }
}
