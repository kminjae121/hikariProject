using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anchor : MonoBehaviour
{
    private Rigidbody2D _rigidCompo;
    [SerializeField] private Rigidbody2D _agentRigidCompo;
    [SerializeField] private GameObject _agent;

    public bool isKnockback;
    private float knockbackPower = 5f;
    private float knockbackTime = 0.5f;

    private void Awake()
    {
        _rigidCompo = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isKnockback = true;
            KnockedBack();
        }
    }

    private void DroppedAnchor()
    {
        StartCoroutine(DropCool());
        _rigidCompo.bodyType = RigidbodyType2D.Dynamic;
    }

    private IEnumerator DropCool()
    {
        float rand = Random.Range(0, 5);
        yield return new WaitForSeconds(5f);
    }

    public void KnockedBack()
    {
        if(isKnockback)
        {
            _rigidCompo.velocity = Vector2.zero;
            _rigidCompo.AddForce(-transform.position.normalized * knockbackPower, ForceMode2D.Impulse);
            print("�˹�");
            //isKnockback = false;
        }
    }
}
