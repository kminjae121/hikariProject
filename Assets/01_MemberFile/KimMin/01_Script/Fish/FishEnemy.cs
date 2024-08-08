using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FishStateEnum
{
    Move,
    Chase,
    Attack
}

public class FishEnemy : FishSetting
{
    public StateMachine StateMachine { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        StateMachine = new StateMachine();
    }

    private void Start()
    {
        StateMachine.Initialize(FishStateEnum.Move, this);
    }
}
