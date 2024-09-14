using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class CheckPlayerCollide : MonoBehaviour
{
    public event Action<string> OnPlayerCollide;
    public string[] targets;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (targets.Contains(collision.name))
        {
            OnPlayerCollide?.Invoke(collision.name);
        }
    }
}
