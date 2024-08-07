using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AnglerFishEnum
{
    Move,
    Chase,
    Attack
}

public class AnglerFishState 
{
    protected AnglerFishStateMachine _anglerFish;

    public AnglerFishState(AnglerFishStateMachine owner, object param)
    {
        _anglerFish = owner;
    }


    public virtual void Enter()
    {

    }

    public virtual void UpdateState()
    {

    }

    public virtual void Exit()
    {

    }

}
