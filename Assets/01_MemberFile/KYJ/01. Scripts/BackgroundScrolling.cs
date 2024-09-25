using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundScrolling : MonoBehaviour
{
    [SerializeField] private float BSpeed = 3f;
    [SerializeField] private float scrollRange = 9.9f;

    public Transform target;


    private void Update()
    {
        transform.position += Vector3.left * BSpeed * Time.deltaTime;

        if (transform.position.x <= -scrollRange)
        {
            transform.position = target.position + Vector3.right * scrollRange;
        }
    }
}


