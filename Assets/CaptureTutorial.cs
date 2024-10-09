using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptureTutorial : MonoBehaviour
{
    [SerializeField]
    private GameObject tutorialCapture;

    public void TutorialEnd()
    {
        gameObject.transform.root.gameObject.SetActive(false);
    }
}
