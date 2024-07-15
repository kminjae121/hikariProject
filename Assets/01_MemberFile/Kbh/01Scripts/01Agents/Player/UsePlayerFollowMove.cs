using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UsePlayerFollowMove : Parts<(
      PlayerObjectData obj,
      IPlayerStatus status
   )>
{
   private bool _isPreviousFollow = false;

   public override void Start()
   {
      _owner.OnUpdateEvt += Update;
   }


   private void Update()
   {
      _data.obj.TargetPosition = _data.obj.MouseWorldPos();
      _data.obj.UseFollowMove = _data.status.State == PlayerState.Grabed;

      if(_isPreviousFollow != _data.obj.UseFollowMove)
      {
         _data.obj.Rigid.velocity = Vector2.zero;
         _isPreviousFollow = _data.obj.UseFollowMove;
      }
   }


   public override void Dispose()
   {
      _owner.OnUpdateEvt -= Update;
   }

   
}
