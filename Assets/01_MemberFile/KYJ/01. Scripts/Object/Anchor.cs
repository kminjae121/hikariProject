using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anchor : MonoBehaviour
{
    private Rigidbody2D _rigidCompo;
    private PlayerMove _agentMove;
    private AnchorSpawner _anchorSpawner;

    [SerializeField] private float knockbackPower = 12f;
    private float knockbackTime = 1.5f;

    private void Awake()
    {
        _rigidCompo = GetComponent<Rigidbody2D>();
        _anchorSpawner = GetComponentInParent<AnchorSpawner>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _agentMove = collision.GetComponent<PlayerMove>();
            if(!_agentMove._isForce)
            KnockedBack(_agentMove.transform.position);
        }
    }

    public void KnockedBack(Vector2 playerDirection)
    {
        _agentMove._isForce = true;
        _agentMove._rigid.velocity = Vector2.zero;

        _agentMove._rigid.AddForce((playerDirection - (Vector2)transform.position) * knockbackPower, ForceMode2D.Impulse);
 
        StartCoroutine(JumpRoutine());

        print("dd");
    }

    private IEnumerator JumpRoutine() //코루틴 뒤에 무조건 Routine 붙이기!
    {
        if(!_agentMove._isForce)
        {
            yield return new WaitForSeconds(knockbackTime);
            _agentMove._isForce = false;
        }
        
    }
}
