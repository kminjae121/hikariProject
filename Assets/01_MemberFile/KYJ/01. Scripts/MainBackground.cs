using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBackground : MonoBehaviour
{
    [SerializeField] private Camera _mainCam;
    [SerializeField] private Transform _mainBackground;

    private void Awake()
    {
        _mainCam = _mainCam.GetComponent<Camera>();
        _mainCam.transform.position = _mainCam.ScreenToWorldPoint(_mainCam.transform.position);
    }

    private void Update()
    {
        _mainBackground.position = new Vector3(_mainCam.transform.position.x, _mainCam.transform.position.y, _mainCam.transform.position.z + 10f);
    }
}
