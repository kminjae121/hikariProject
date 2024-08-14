using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AgentMove : MonoBehaviour
{
    public UnityEvent JumpEvent;

    [field: SerializeField] public InputReader PlayerInput { get; private set; }

    public AgentMovement MovementCompo { get; protected set; }

    private void Awake()
    {
        MovementCompo = GetComponent<AgentMovement>();
        PlayerInput.JumpKeyEvent += HandleJumpKeyEvent;
    }

    private void OnDestroy()
    {
        PlayerInput.JumpKeyEvent -= HandleJumpKeyEvent;
    }

    private void Update()
    {
        MovementCompo.SetMovement(PlayerInput.Movement.x);
    }

    private void HandleJumpKeyEvent()
    {
        if (MovementCompo.isGround.Value)
        {
            JumpProcess();
        }
    }

    private void JumpProcess()
    {
        JumpEvent?.Invoke();
        MovementCompo.Jump();
    }
}
