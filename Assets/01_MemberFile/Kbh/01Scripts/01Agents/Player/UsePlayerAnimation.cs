using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UsePlayerAnimation : 
   Parts<(
      IMovement movement,
      IPlayerStatus status,
      AnimationData animation,
      CastData groundChecker
   )>
{
   private readonly int _idleHash = Animator.StringToHash("Idle");
   private readonly int _RunHash = Animator.StringToHash("Run");
   private readonly int _fallingHash = Animator.StringToHash("Falling");
   private readonly int _JumpHash = Animator.StringToHash("Jump");
   private readonly int _GrabedHash = Animator.StringToHash("Grabed");
   private readonly int _GrabHash = Animator.StringToHash("Grab");

   
   public override void Start()
   {
      _owner.OnUpdateEvt += Update;
   }


   private void Update()
   {
      int applingHash = 0;
      switch (_data.status.State)
      {
         case PlayerState.Movable:
            applingHash = MovableAnim();
            break;

         case PlayerState.Grab:
            applingHash = _GrabHash;
            break;

         case PlayerState.Grabed:
            applingHash = _GrabedHash;
            break;
      }

      _data.animation.ChangeAnimation(applingHash);
   }

   private int MovableAnim()
   {
      bool isGround = _data.groundChecker.Cast();

      if (isGround)
      {
         if(_data.movement.Rigid.velocity.x == 0)
            return _idleHash;
         else
            return _RunHash;
      }
      else
      {
         if (_data.movement.Rigid.velocity.y > 0)
            return _JumpHash;
         else
            return _fallingHash;
      }
   }

   public override void Dispose()
   {
      _owner.OnUpdateEvt -= Update;
      base.Dispose();
   }


}
