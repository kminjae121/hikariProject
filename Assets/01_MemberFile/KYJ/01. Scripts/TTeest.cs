using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TTeest : MonoBehaviour
{
        [SerializeField] private Transform _target;
        public Transform _p1, _p2, _p3;
        public float _duration;

        private void Start()
        {
        StartCoroutine(COR_BezierCurves());

    }
    private void Update()
    {
        float time = 0f;

        //while (true)
        //{
        if (time > 1f)
        {
            time = 0f;
        }

        Vector3 p4 = Vector3.Lerp(_p1.position, _p2.position, time);
        Vector3 p5 = Vector3.Lerp(_p2.position, _p3.position, time);
        _target.position = Vector3.Lerp(p4, p5, time);

        time += Time.deltaTime / 4;

    }


    IEnumerator COR_BezierCurves(float duration = 1.0f)
        {
           
                yield return null;
            }
        //}
    }
