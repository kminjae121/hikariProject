using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;

public class StartUI : MonoBehaviour
{
    [SerializeField] private Image _titleObj;
    [SerializeField] private TextMeshProUGUI _title;

    [SerializeField] private Image _menuObj;
    [SerializeField] private GameObject[] button;


    private void Update()
    {
        TitleUI();
        StartCoroutine(MenuUICoroutine());

        BtnUI();
    }

    private void MenuUI()
    {
        _menuObj.GetComponent<RectTransform>().DOAnchorPosX(-400,1);
    }

    private void TitleUI()
    {
        _titleObj.DOFade(1, 2);
        _title.DOFade(1,2);
        StartCoroutine(TitleCoroutine());
    }

    private void BtnUI()
    {
        for (int i = 0; i < button.Length; i++)
        {
            button[i].GetComponent<Image>().DOFade(1, 2);
        }
    }


    private IEnumerator TitleCoroutine()
    {
        yield return new WaitForSeconds(4f);
        _titleObj.GetComponent<RectTransform>().DOAnchorPos(new Vector3(-400, 340, transform.position.z), 2);
    }
    
    private IEnumerator MenuUICoroutine()
    {
        yield return new WaitForSeconds(4f);
        MenuUI();
    }
}
