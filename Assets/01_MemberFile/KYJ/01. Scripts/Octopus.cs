using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Octopus : MonoBehaviour
{
    [Header("Luminescent Plants Visual Input")]
    [SerializeField] private BrightPlants _brightPlants;

    [Header("Player Input")]
    [SerializeField] private PlayerMove _PlayerMove;

    [Header("Knockback Setting")]
    [SerializeField] private float knockbackPower = 12f;
    public bool _canKnockback;
    private float knockbackTime = 0.5f;

    private float size = 1f;
    public LayerMask targetMask;


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
            _PlayerMove._isForce = true;
            _PlayerMove._rigid.velocity = Vector2.zero;

            _PlayerMove._rigid.AddForce(((Vector2)_PlayerMove.transform.position - (Vector2)transform.position) * knockbackPower, ForceMode2D.Impulse);

            StartCoroutine(JumpRoutine());
        }
    }

    private IEnumerator JumpRoutine() //코루틴 뒤에 무조건 Routine 붙이기!
    {
        if (_PlayerMove._isForce)
        {
            yield return new WaitForSeconds(knockbackTime);
            _PlayerMove._isForce = false;
            _canKnockback = false;
        }
    }
}
