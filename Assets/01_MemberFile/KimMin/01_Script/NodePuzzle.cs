using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

public class NodePuzzle : MonoBehaviour
{
    const int SIZE = 10;
    const int RANGE = 100000;

    private Button[] _valueBtn;
    private TextMeshProUGUI[] _valueTxt;
    private RawImage[] _nodes;
    private int[] _valueOrder = new int[4]; //값들의 순서를 저장하는 배열
    private int[,] _valueArr = new int[4, SIZE]; //실질적인 값이 들어가는 배열
    private int[] answer = new int[4];

    private float _sum = 0; //현재 값들의 합
    [SerializeField] private float _approxRatio, _ratio, _prevApproxRatio;
    private float _currentVelocity;

    private bool _isStart;

    private TextMeshProUGUI _reqTxt;
    private TextMeshProUGUI _sumTxt;

    [SerializeField] private Slider _approxSlider;
    [SerializeField] private int _answer; //정답

    private void Awake()
    {
        Assignment();
        InitializePuzzle();
    }

    private void Update()
    {
        if (_isStart)
        {
            float current = Mathf.SmoothDamp(_approxSlider.value, _ratio, ref _currentVelocity, 0.1f, 5f);
            _approxSlider.value = current;
        }
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
        _answer = Random.Range(RANGE / 10, RANGE);
        StartCoroutine(DesireTextAnim());

        for (int i = 0; i < 3; i++)
        {
            answer[i] = Random.Range
                (0, _answer / 4);

            answer[i] = CheckOdd(answer[i], i);

            sum += answer[i];
        }

        answer[3] = _answer - sum;

        for (int i = 0; i < 4; i++)
        {
            int index = Random.Range(0, SIZE);
            for (int j = 0; j < SIZE; j++)
            {
                if (j == index)
                    _valueArr[i, j] = answer[i];
                else
                {
                    _valueArr[i, j] = SetValueArr(j + 1);
                    _valueArr[i, j] = CheckOdd(_valueArr[i, j], i);
                }
            }
        }

        for (int i = 0; i < 4; i++)
        {
            SetReqireButton(i);
        }

        GetSum();
    }

    private int CheckOdd(int num, int index)
    {
        if (index % 2 == 0)
        {
            if (num % 2 == 0) num++;
            else num--;
        }
        else
        {
            if (num % 2 == 0) num--;
            else num++;
        }

        return num;
    }

    private int SetValueArr(int j)
    {
        int min = ((j * j) * 10) * (j * 10);
        int max = (j * j) * 20 * (j * 10);

        return Random.Range(min, max);
    }

    private void SetReqireButton(int index) //버튼 현재 카운트 설정
    {
        int rand = Random.Range(0, SIZE - 1);

        _valueOrder[index] = rand;
        _valueTxt[index].text = _valueArr[index, rand].ToString();
    }

    public void OnReqireClick() //버튼 클릭
    {
        string button = EventSystem.current
            .currentSelectedGameObject.name.ToString();

        int index = int.Parse(button.Substring(button.Length - 1)) - 1;

        _valueOrder[index]++;

        if (_valueOrder[index] >= SIZE)
            _valueOrder[index] = 0;

        _valueTxt[index].text = _valueArr
            [index, _valueOrder[index]].ToString();

        GetSum();
        ApproximateRatio();
    }

    private void GetSum()
    {
        _sum = 0;

        for (int i = 0; i < 4; i++)
            _sum += _valueArr[i, _valueOrder[i]];

        _sumTxt.text = $"합계 : {_sum}";
    }

    private void ApproximateRatio()
    {
        _approxRatio = (_answer - _sum) / _answer;

        if (_approxRatio > 0)
        {
            _ratio = 1 - _approxRatio;
            _prevApproxRatio = _ratio;
        }
        else
        {
            _ratio = 1 - Mathf.Abs(_approxRatio);
            _prevApproxRatio -= _ratio;
        }

        _isStart = true;

        if (1 - _ratio <= 0.05f)
            Sucess();
    }

    private void Sucess()
    {
        Debug.Log("정답");

        foreach (RawImage node in _nodes)
        {
            node.DOColor(Color.green, 1.5f);
        }
    }

    private IEnumerator DesireTextAnim() //숫자 바뀌는 효과
    {
        for (int i = 0; i < 25; i++)
        {
            _reqTxt.text = Random.Range(0, RANGE).ToString();
            yield return new WaitForSeconds(0.05f);
        }

        _reqTxt.text = _answer.ToString();
    }
}
