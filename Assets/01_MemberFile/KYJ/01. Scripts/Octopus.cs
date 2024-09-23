using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Octopus : MonoBehaviour
{
    [SerializeField] private PlayerMove _agentMove;

    [SerializeField] private float knockbackPower = 12f;
    private float knockbackTime = 0.5f;

    private BrightFoothold _brightFoothold;
    [SerializeField] private BrightPlants _brightPlants;

    private void Awake()
    {
        _brightFoothold = GetComponent<BrightFoothold>();   
    }

    public void OctopusKnockback()
    {
        if (_brightFoothold.brightnessLevel != _brightPlants.brightStep)
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
        }
    }
}
