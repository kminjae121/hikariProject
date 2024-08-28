using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class NodePuzzle : MonoBehaviour
{
    private Button[] _valueBtn;
    private TextMeshProUGUI[] _valueTxt;
    private RawImage[] _nodes;
    private int[] _valueOrder = new int[4];
    private int[,] _valueArr = new int[4, 10];

    private TextMeshProUGUI _reqTxt;
    private TextMeshProUGUI _sumTxt;

    private int _sum = 0;

    [Range(0, 100000), SerializeField] private int _range;
    [SerializeField] private int[] Answer = new int[4];
    [SerializeField] private int _answer;

    private void Awake()
    {
        Assignment();
        InitializePuzzle();
    }

    private void Assignment()
    {
        _valueBtn = new Button[4];
        _valueTxt = new TextMeshProUGUI[4];
        _nodes = new RawImage[4];

        _reqTxt = GameObject.Find("DesireNumberText").GetComponent<TextMeshProUGUI>();
        _sumTxt = GameObject.Find("SumText").GetComponent<TextMeshProUGUI>();


        for (int i = 0; i < 4; i++)
        {
            _valueBtn[i]
                = GameObject.Find($"ValueButton{i + 1}").GetComponent<Button>();
            _valueTxt[i]
                = GameObject.Find($"ValueText{i + 1}").GetComponent<TextMeshProUGUI>();
            _nodes[i]
                = GameObject.Find($"Node{i + 1}").GetComponent<RawImage>();
        }
    }

    private void InitializePuzzle() //퍼즐 초기화
    {
        int sum = 0;
        _answer = Random.Range(0, _range);
        StartCoroutine(DesireTextAnim());

        int[] answer = new int[4];

        for (int i = 0; i < 3; i++)
        {
            answer[i] = Random.Range
                (i * (_answer / 2), _answer);

            sum += answer[i];
        }

        answer[3] = _answer - sum;

        for (int i = 0; i < 4; i++)
            Answer[i] = answer[i];

        for(int i = 0; i < 4; i++)
        {
            int index = Random.Range(0, 10);
            for (int j = 0; j < 10; j++)
            {
                if (j == index)
                    _valueArr[i, j] = answer[i];
                else
                    _valueArr[i, j] = Random.Range(j^3 * 100, j^3 * 1000);
            }
        }

        for (int i = 0; i < 4; i++)
        {
            SetReqireButton(i);
        }

        GetSum();
    }

    private void SetReqireButton(int value) //버튼 현재 카운트 설정
    {
        int rand = Random.Range(1, 11);

        _valueOrder[value] = rand;
        _valueTxt[value].text = _valueArr[value, rand - 1].ToString();
    }

    public void OnReqireClick() //버튼 클릭
    {
        string button = EventSystem.current
            .currentSelectedGameObject.name.ToString();

        int index = int.Parse(button.Substring(button.Length - 1)) - 1;

        GetSum();

        _valueTxt[index].text = _valueArr
            [index, _valueOrder[index]].ToString();

        _valueOrder[index]++;

        if (_valueOrder[index] >= 10)
            _valueOrder[index] = 0;
    }

    private void GetSum()
    {
        _sum = 0;

        for (int i = 0; i < 4; i++)
            _sum += _valueArr[i, _valueOrder[i]];

        _sumTxt.text = $"합계 : {_sum}";
    }

    private IEnumerator DesireTextAnim() //숫자 바뀌는 효과
    {
        for (int i = 0; i < 25; i++)
        {
            _reqTxt.text = Random.Range(0, _range).ToString();
            yield return new WaitForSeconds(0.05f);
        }

        _reqTxt.text = _answer.ToString();
    }
}
