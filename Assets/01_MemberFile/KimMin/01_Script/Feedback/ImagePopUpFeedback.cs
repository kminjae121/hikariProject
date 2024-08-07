using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImagePopUpFeedback : Feedback
{
    [SerializeField] private GameObject _popUpObject; //팝업 게임오브젝트
    [SerializeField] private GameObject _targetToSpawn; //스폰할 위치 타겟
    [SerializeField] private float _spawnRadius; //타겟에서 생성될 거리 범위
    [SerializeField] private int _timeToRepeat; //생성될 횟수
    [SerializeField] private List<Sprite> _spriteList; //팝업 이미지 리스트

    private SpriteRenderer _spriteRenderer;

    [Range(0, 30)] //에디터에서 슬라이더로 뜨게 하는거
    [SerializeField] private float _spawnTime; //생성 시간

    private void Awake()
    {
        _spriteRenderer = _popUpObject.GetComponent<SpriteRenderer>();
    }

    public override void PlayFeedback()
    {
        StartCoroutine(PopUpCoroutine());
    }

    public override void StopFeedback()
    {
        
    }

    private Vector3 GetSpawnPos() //스폰 위치 설정 매소드
    {
        Vector3 spawnPos = _targetToSpawn.transform.position +
            (Vector3)Random.insideUnitCircle * _spawnRadius; //타겟의 주변 반경으로 위치 설정

        return spawnPos;
    }

    private void GeneratePopUp()
    {
        _spriteRenderer.sprite = _spriteList[Random.Range(0, _spriteList.Count)]; //팝업 이미지 랜덤으로 변경
        Vector3 spawnPos = GetSpawnPos(); //스폰 위치 받아오기
        Instantiate(_popUpObject, spawnPos, Quaternion.identity, transform); //팝업 생성
    }

    private IEnumerator PopUpCoroutine()
    {
        for (int i = 0; i < _timeToRepeat; i++) //반복 횟수만큼 반복
        {
            yield return new WaitForSeconds(_spawnTime);
            GeneratePopUp();
        }
    }
}
