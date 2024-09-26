using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheckPoint : MonoBehaviour
{
    private Vector3 _savedPos;

    private void Awake()
    {
        _savedPos = transform.localPosition; 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SavePos"))
        {
            SavePosition();
        }
        else if (collision.CompareTag("ResetPos"))
        {
            OnResetPosition();
        }
    }

    private void OnResetPosition()
    {
        transform.localPosition = _savedPos;
    }

    private void SavePosition()
    {
        _savedPos = transform.position;
    }
}
