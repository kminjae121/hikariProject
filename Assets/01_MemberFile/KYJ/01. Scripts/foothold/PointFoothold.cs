using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointFoothold : MonoBehaviour
{
    [Header("Position Setting")]
    [SerializeField] private Transform _startPos;
    [SerializeField] private Transform _endPos;

    [Header("Speed Setting")]
    [SerializeField] private float _moveSpeed;

    private Transform[] _movePoints = new Transform[2];


    private void Awake()
    {
        _movePoints[0] = _startPos;
        _movePoints[1] = _endPos;

        transform.position = _startPos.position;
    }

    private void FixedUpdate()
    {
        MoveFoothold(_moveSpeed); 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }

    private void MoveFoothold(float moveSpeed)
    {
        transform.position =
            Vector3.MoveTowards(transform.position, _movePoints[1].position, moveSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, _movePoints[1].position) <= 0.05f)
        {
            if (_movePoints[1] == _endPos)
            {
                _movePoints[1] = _movePoints[0];
            }

            else
            {
                _movePoints[1] = _endPos;
            }
        }
    }
}
