using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageText : MonoBehaviour
{
    public List<GameObject> CaptureText = new List<GameObject>();

    private void Awake()
    {
        CaptureText.ForEach(c => c.SetActive(false));
    }

    private void Start()
    {
    }
}
