using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UsePlayerInterect : Parts<(
      PlayerObjectData obj,
      IPlayerStatus status
   )>
{

   public override void Start()
   {
      _owner.OnUpdateEvt += Update;
   }

   private void Update()
   {
      if (_data.obj.IsGrab)
      {
         _data.status.State = PlayerState.Grabed;
      }
         
      if(!_data.obj.IsGrab)
      {
         _data.status.State = PlayerState.Movable;
      }
   }

   public override void Dispose()
   {
      _owner.OnUpdateEvt -= Update;
   }

   
}
