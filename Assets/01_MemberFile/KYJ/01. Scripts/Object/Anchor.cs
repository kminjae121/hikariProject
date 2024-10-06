using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anchor : MonoBehaviour
{
    private PlayerMove _agentMove;

    [SerializeField] private float knockbackPower = 12f;

    private void Awake()
    {
        _agentMove = GameObject.Find("PlayerPrefab").GetComponent<PlayerMove>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!_agentMove._isForce)
                KnockedBack(_agentMove.transform.position);
        }
    }

    public void KnockedBack(Vector2 playerDirection)
    {
        _agentMove._isForce = true;
        _agentMove._rigid.velocity = Vector2.zero;

        _agentMove._rigid.AddForce((playerDirection - (Vector2)transform.position) * knockbackPower, ForceMode2D.Impulse);
    }
}
