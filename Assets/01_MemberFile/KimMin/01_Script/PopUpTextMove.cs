using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpTextMove : MonoBehaviour
{
    private Vector3 _moveDir;
    
    private void Start()
    {
        float x = Random.Range(-0.2f, 0.2f);
        float y = Random.Range(-0.2f, 0.2f);

        _moveDir = new Vector3(x, y, 0);
    }

    private void Update()
    {
        transform.position += _moveDir;
    }
}
