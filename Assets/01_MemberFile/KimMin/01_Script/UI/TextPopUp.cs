using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.Events;

public class TextPopUp : MonoBehaviour
{
    public UnityEvent OnPopUpEvent;

    [SerializeField] private TMP_Text _popUpText;
    [SerializeField] private GameObject _canvas;

    [SerializeField] private float _interval; //생성되는 쿨타임
    [SerializeField] private float _duration; //글자가 떠있는 시간

    private Vector3 _maxSpawnPos;
    private Vector3 _minSpawnPos;

    private string[] _popUpTexts =
    {
        "Go Back",
        "Deep",
        "Darkness",
        "Run Away",
        "Get Out"
    }; //랜덤으로 생성될 텍스트 메시지

    private void Update()
    {
        GetSpawnPos(); //플레이어 위치를 가져온다

        if (Input.GetKeyDown(KeyCode.R))
        {
            StartGenerateText();
        }
    }

    private Vector2 GetSpawnPos() //스폰 위치 설정 매소드
    {
        Vector2 spawnPos = Camera.main.ViewportToScreenPoint(new Vector2(
            Random.Range(0.15f, 0.85f), Random.Range(0.15f, 0.85f)));

        return spawnPos;
    }

    private void GenerateText() //팝업 텍스트 생성
    {
        Vector3 spawnPos = GetSpawnPos(); //스폰 위치 설정
        Quaternion rotation = new Quaternion(0, 0, Random.Range(-30, 30), 180f);

        TMP_Text newText = Instantiate(_popUpText, spawnPos, rotation,
            _canvas.transform); //텍스트 생성

        newText.text = _popUpTexts[Random.Range(0, _popUpTexts.Length)]; //텍스트 글자 설정

        newText.DOFade(0f, _duration); //서서히 사라진다
    }

    public void StartGenerateText() //이벤트 발동시 실행되는 매소드
    {
        StartCoroutine(GenerateTextCoroutine());
    }

    private IEnumerator GenerateTextCoroutine() //텍스트 생성 매소드를 실행시켜주는 코루틴
    {
        for (int i = 0; i < 10; i++)
        {
            GenerateText();
            yield return new WaitForSeconds(_interval);
        }
    }
}
