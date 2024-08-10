using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnglerFishAttackState : AnglerFishState
{
    public AnglerFishAttackState(FishEnemy _onwer, StateMachine state, string animHashName) : base(_onwer, state, animHashName)
    {
    }
}
