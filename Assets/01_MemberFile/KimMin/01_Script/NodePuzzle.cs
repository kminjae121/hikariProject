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
    [SerializeField] private Button[] _reqireButtons;
    [SerializeField] private Button _desireButton;

    [SerializeField] private TextMeshProUGUI[] _reqireTexts;
    [SerializeField] private TextMeshProUGUI _desireText;
    [SerializeField] private TextMeshProUGUI _sumText;

    [SerializeField] private int[] Answer = new int[4];

    [Range(0, 100000)]
    [SerializeField] private int _range;

    [Header("디버그 전용")]
    [SerializeField] private int _answer;
    [SerializeField] private int[,] _reqireNumbers = new int[4, 10];
    [SerializeField] private int[] _reqireCount = new int[4];

    private void Awake()
    {
        InitializePuzzle();
    }

    private void InitializePuzzle()
    {
        _answer = Random.Range(0, _range);
        StartCoroutine(DesireTextAnim());

        int[] answerNumbers = new int[4];
        int sum = 0;

        for (int i = 0; i < 3; i++)
        {
            answerNumbers[i] = Random.Range
                (i * (_answer / 4), _answer);

            sum += answerNumbers[i];
        }

        answerNumbers[3] = _answer - sum;

        for (int i = 0; i < 4; i++)
        {
            Answer[i] = answerNumbers[i];
        }

        for(int i = 0; i < 4; i++)
        {
            int index = Random.Range(0, 10);
            for (int j = 0; j < 10; j++)
            {
                if (j == index)
                    _reqireNumbers[i, j] = answerNumbers[i];
                else
                    _reqireNumbers[i, j] = Random.Range(j^3 * 100, j^3 * 1000);
            }
        }

        for (int i = 0; i < 4; i++)
        {
            SetReqireButton(i);
        }
    }

    private void SetReqireButton(int reqIndex) //버튼 현재 카운트 설정
    {
        int rand = Random.Range(0, 10);

        _reqireCount[reqIndex] = rand;
        _reqireTexts[reqIndex].text = _reqireCount[reqIndex].ToString();
    }

    public void OnReqireClick() //버튼 클릭
    {
        int sum = 0;
        string button =
            EventSystem.current.currentSelectedGameObject.name.ToString();

        int index = int.Parse(button.Substring(button.Length - 1)) - 1;

        _reqireTexts[index].text = _reqireNumbers
            [index, _reqireCount[index]].ToString();

        _reqireCount[index]++;

        if (_reqireCount[index] >= 9)
            _reqireCount[index] = 0;

        for (int i = 0; i < 4; i++)
        {
            sum += _reqireNumbers[i, _reqireCount[i]];
        }
        _sumText.text = sum.ToString();
    }

    private IEnumerator DesireTextAnim() //숫자 바뀌는 효과
    {
        for (int i = 0; i < 25; i++)
        {
            _desireText.text = Random.Range(0, _range).ToString();
            yield return new WaitForSeconds(0.05f);
        }

        _desireText.text = _answer.ToString();
    }
}
