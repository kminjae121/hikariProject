using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingVine : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Transform[] _way;

    private Transform _targetWay;
    private int _wayCount;

    private void Update()
    {
        TargetWay();
    }

    private void TargetWay()
    {
        _targetWay = _way[_wayCount];

        Vector3 dir = _targetWay.position - transform.position;
        Vector3 moveDir = dir.normalized;

        transform.position += moveDir * _moveSpeed * Time.deltaTime;

        if (Vector3.Distance(transform.position, _targetWay.position) < 0.5f)
        {
            _wayCount++;
            if (_wayCount >= _way.Length)
            {
                _wayCount = 0;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
            collision.transform.SetParent(transform);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
            collision.transform.SetParent(null);
    }
}
