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
        startUI._menuObj.DOFade(0.5f, 1);
        soundUI.GetComponent<RectTransform>().DOAnchorPosX(-400, 1);
    }

    public void BackBtn()
    {
        soundUI.GetComponent<RectTransform>().DOAnchorPosX(400, 1);
        startUI._menuObj.DOFade(1, 1);
    }

    private IEnumerator BtnCoroutine()
    {
        yield return new WaitForSeconds(3f);
        startUI._menuObj.gameObject.SetActive(false);

    }
}
