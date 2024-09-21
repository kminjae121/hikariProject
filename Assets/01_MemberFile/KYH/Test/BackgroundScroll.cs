using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
	[SerializeField] private float _moveSpeed;
    [SerializeField] private float scrollRange;

   public Transform target;
    private void Update()
    {
        transform.position += Vector3.right * _moveSpeed * Time.deltaTime;

        if (transform.position.x <= -scrollRange)
        {
            transform.position = target.position + Vector3.right * scrollRange;
        }
    }
}

