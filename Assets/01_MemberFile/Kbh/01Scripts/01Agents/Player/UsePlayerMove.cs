using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UsePlayerMove : Parts<(
      IPlayerStatus status,
      PlayerObjectData obj,
      CastData groundChecker
   )>
{
   private Tween _updateTween = null;

   public override void Start()
   {
      _updateTween = DOVirtual.DelayedCall(Time.fixedDeltaTime, FixedUpdate)
         .SetUpdate(UpdateType.Fixed).SetLoops(-1);
   }

   private void FixedUpdate()
   {
      bool movable = _data.status.State == PlayerState.Movable;
      _data.obj.CanMove = movable;
      if (movable)
      {
         Move();
         Jump();
      }

   }

   private void Move()
   {
      float xVelocity = Input.GetAxisRaw("Horizontal")
               * _data.status.Speed;

      _data.obj.ForceX = xVelocity;
   }

   private void Jump()
   {
      if (Input.GetKeyDown(KeyCode.Space) && _data.groundChecker.Cast())
      {
         _data.obj.Jump(_data.status.JumpPower);
      }
   }

   public override void Dispose()
   {
      _updateTween.Kill();
   }


}
