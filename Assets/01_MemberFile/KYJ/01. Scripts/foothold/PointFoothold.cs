using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointFoothold : MonoBehaviour
{
    [SerializeField] private Transform[] _points;
    [SerializeField] private float _moveSpeed;

    public Transform _endPos;

    private bool oo;

    private void Awake()
    {
        transform.position = _points[0].position;
        _points[1] = _endPos;
    }

    private void FixedUpdate()
    {
        MoveFoothold(_moveSpeed); 
    }

    private void MoveFoothold(float moveSpeed)
    {
        transform.position =
            Vector3.MoveTowards(transform.position, _points[1].position, moveSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, _points[1].position) <= 0.05f && !oo)
        {
            if (_points[1] == _endPos)
            {
                _points[1] = _points[0];
            }

            else
            {
                _points[1] = _endPos;
            }

            StartCoroutine(MoveWaitRotain());
        }
    }

    private IEnumerator MoveWaitRotain()
    {
        oo = true;
        yield return new WaitForSeconds(3f);
        print("d");
        oo = false;
    }
}
