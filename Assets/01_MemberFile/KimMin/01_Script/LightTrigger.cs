using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTrigger : MonoBehaviour
{
    [SerializeField] GameObject _target;

    private Transform _visual;

    private LineRenderer _lineRenderer;

    private void Awake()
    {
        _lineRenderer = GameObject.Find("Line").GetComponent<LineRenderer>();
        _visual = gameObject.transform.Find("Visual").transform;
    }

    private void Update()
    {
        DrawingLine();
    }

    private void DrawingLine()
    {
        _lineRenderer.SetPosition(0, _visual.position);
        _lineRenderer.SetPosition(1, _target.transform.position);
    }

    public void OnTargetLight()
    {

    }
}
