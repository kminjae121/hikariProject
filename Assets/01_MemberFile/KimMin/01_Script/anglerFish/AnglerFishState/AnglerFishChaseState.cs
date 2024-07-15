using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnglerFishChaseState : AnglerFishState
{
    private readonly LayerMask _playerLayer = LayerMask.GetMask("Player");

    public AnglerFishChaseState(AnglerFish onwer) : base(onwer)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void UpdateState()
    {
        base.UpdateState();

        Vector2 dir = _anglerFish.targetTrm.position - _anglerFish.transform.position;
        float distance = dir.magnitude;

        if (distance < _anglerFish.detectRadius)
        {
            _anglerFish.ChangeState(AnglerFishEnum.Attack);
            return;
        }

        if (distance > _anglerFish.detectRadius + 4f)
        {
            _anglerFish.ChangeState(AnglerFishEnum.Move);
            return;
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
