using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _controlPanel;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _controlPanel.SetActive(true);
        }
    }
}
