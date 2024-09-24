using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Octopus : MonoBehaviour
{
    [SerializeField] private PlayerMove _agentMove;

    [SerializeField] private float knockbackPower = 12f;
    private float knockbackTime = 0.5f;
    public bool _canKnockback;

    private BrightFoothold _brightFoothold;
    [SerializeField] private BrightPlants _brightPlants;

    private float size = 1f;
    public LayerMask targetMask;

    private void Awake()
    {
        _brightFoothold = GetComponent<BrightFoothold>();   
    }

    public void BrightnessRange()
    {
        Collider2D octopusOverlap = Physics2D.OverlapCircle(transform.position, size, targetMask);

        if (octopusOverlap)
        {
            _canKnockback = true;
            OctopusKnockback();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, size);
    }

    public void OctopusKnockback()
    {
        if (_canKnockback)
        {
            _agentMove._isForce = true;
            _agentMove._rigid.velocity = Vector2.zero;

            _agentMove._rigid.AddForce(((Vector2)_agentMove.transform.position - (Vector2)transform.position) * knockbackPower, ForceMode2D.Impulse);

            StartCoroutine(JumpRoutine());
        }
    }

    private IEnumerator JumpRoutine() //코루틴 뒤에 무조건 Routine 붙이기!
    {
        if (_agentMove._isForce)
        {
            yield return new WaitForSeconds(knockbackTime);
            _agentMove._isForce = false;
            _canKnockback = false;
        }
    }
}
