using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monosingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<T>();
                if (instance == null)
                {
                    Debug.Log("스크립트 누락");
                }
            }
            return instance;
        }
    }
}