using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnglerFishMovement : MonoBehaviour
{
    private Rigidbody2D _rigid;
    private RaycastHit2D _hit;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
    }

    public void Move(float move, LayerMask layer)
    {
        _rigid.AddForce(Vector2.right * move * Time.deltaTime, ForceMode2D.Impulse);

        _hit = Physics2D.Raycast(transform.position, Vector2.right, 1f, layer);

        if (_hit)
        {
            ChangeDirection();
        }
    }

    private void ChangeDirection()
    {
        transform.localRotation = Quaternion.Euler(0, 180, 0);
    }
}
