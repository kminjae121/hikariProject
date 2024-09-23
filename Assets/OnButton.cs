using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnButton : MonoBehaviour
{
    public GameObject invokePanel;

    [SerializeField]
    private GameObject explainPanel;

    public void ActiveSettingPanel()
    {
        invokePanel.SetActive(true);
    }

    public void CancelButton()
    {
        invokePanel.SetActive(false);
    }
    public void ExplainButton()
    {
        explainPanel.SetActive(true);
    }

    public void ExitExplainButton()
    {
        explainPanel.SetActive(false);
    }
}
