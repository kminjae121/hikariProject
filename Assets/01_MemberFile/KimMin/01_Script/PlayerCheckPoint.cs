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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "SavePos")
        {
            SavePosition();
        }
        else if (collision.transform.tag == "ResetPos")
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
