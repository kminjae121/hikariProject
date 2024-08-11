using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEndTrigger : MonoBehaviour
{
    [SerializeField] private FishSetting _fish;

    public void AnimationEnd()
    {
        _fish.AnimationEndTrigger();
    }

    public void AnimationAttackTrigger()
    {
        _fish.Attack();
    }
}
