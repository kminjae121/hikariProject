using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.Events;

public class PopUp : MonoBehaviour
{
    public UnityEvent OnPopUpEvent;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            OnPopUpEvent?.Invoke();
        }
    }
}
