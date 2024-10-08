using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestPopupUI : MonoBehaviour
{
    [SerializeField] private string[] _questDialogue;
    [SerializeField] private TextMeshProUGUI _questTxt;
    private int currentQuest = 0;

    private void Start()
    {
        _questTxt.text = _questDialogue[0];
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            QuestTxt();
        }
    }

    public void QuestTxt()
    {
        _questTxt.text = _questDialogue[currentQuest];
        currentQuest++;
    }
}
