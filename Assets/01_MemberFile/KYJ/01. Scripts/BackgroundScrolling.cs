using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundScrolling : MonoBehaviour
{
    public Camera cam;
    public Transform target;

    public Vector2 _startPos;
    public float _startZ;

    private Vector2 campos => (Vector2)cam.transform.position - _startPos;
    private float zTarget => transform.position.z - target.transform.position.z;

    private float cliping => (cam.transform.position.z + (zTarget) > 0 ? cam.farClipPlane : cam.nearClipPlane);

    private void Awake()
    {
        _startPos = transform.position;
        _startZ = transform.localPosition.z;
    }

    private void Update()
    {
        Vector2 newPos = _startPos * 

    }
}

