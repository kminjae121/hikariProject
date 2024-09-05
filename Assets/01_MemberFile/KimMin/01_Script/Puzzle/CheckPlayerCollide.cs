using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CheckPlayerCollide : MonoBehaviour
{
    public event Action OnPlayerCollide;
    public event Action OnKeyHoleCollide;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            OnPlayerCollide?.Invoke();
        }
        else if (collision.CompareTag("KeyHole"))
        {
            OnKeyHoleCollide?.Invoke();
        }
    }
}
