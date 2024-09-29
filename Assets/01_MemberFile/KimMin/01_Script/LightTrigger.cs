using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTrigger : MonoBehaviour
{
    [SerializeField] GameObject _target;

    private Transform _visual;
    private LineRenderer _lineRenderer;

    private bool _isEnabled;
    private Vector3[] linePos = new Vector3[2];

    private void Awake()
    {
        _lineRenderer = GameObject.Find("Line").GetComponent<LineRenderer>();
        _visual = gameObject.transform.Find("Visual").transform;
    }

    private void Update()
    {
        if (_isEnabled)
            DrawingLine();
    }

    private void DrawingLine()
    {
        linePos[0] = _visual.position;
        linePos[1] = _target.transform.position;

        _lineRenderer.positionCount = linePos.Length;
        _lineRenderer.SetPositions(linePos);
    }

    public void OnTargetLight()
    {
        _isEnabled = true;
    }

    public void OffTargetLight()
    {
        _lineRenderer.positionCount = 0;
        _isEnabled = false;
    }
}
