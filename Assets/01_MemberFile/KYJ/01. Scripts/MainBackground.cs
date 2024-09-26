using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBackground : MonoBehaviour
{
    [SerializeField] private Camera _mainCam;
    [SerializeField] private Transform _target;

    private void Awake()
    {
        _mainCam = GetComponent<Camera>();

        _mainCam.transform.position = _mainCam.ScreenToWorldPoint(_mainCam.transform.position);
        _target.position = _mainCam.transform.position;
    }

    private void Update()
    {
        _target.position = _mainCam.transform.position;
    }
}
