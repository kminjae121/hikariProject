using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AnglerFishEnum
{
    Idle,
    Move,
    Chase,
    Attack
}

public class AnglerFishState : MonoBehaviour
{
    protected AnglerFish _anglerFish;

    public AnglerFishState(AnglerFish owner)
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
