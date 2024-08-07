using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UseUIDragMove : Part<IInterctable>
{
   private bool isDuringGrabAction;
   private Vector2 lastPanelPosition;
   private Vector2 lastMousePosition;

   public override void Start()
   {
      _owner.OnUpdateEvt += HandleUpdate;
   }

   private void HandleUpdate()
   {
      if (_data.IsGrab && !isDuringGrabAction)
      {
         lastPanelPosition = _owner.GetTrm().position;
         lastMousePosition = ConvertPositionWithType(Input.mousePosition);
         _owner.OnUpdateEvt += HandleGrab;
         isDuringGrabAction = true;
      }
      else
      {
         _owner.OnUpdateEvt -= HandleGrab;
         isDuringGrabAction = false;
      }
   }



   private void HandleGrab()
   {
      Vector2 currentPosition = ConvertPositionWithType(Input.mousePosition);
      Vector2 delta = currentPosition - lastMousePosition;
      _owner.GetTrm().position = lastPanelPosition + delta*2;
   }

   public override void Dispose()
   {
      _owner.OnUpdateEvt -= HandleUpdate;
      base.Dispose();
   }

   private Vector2 ConvertPositionWithType(Vector3 mousePosition)
   {
      switch (_data.InstanceType)
      {
         case InterectInstanceType.World:
            return _data.Main.ScreenToWorldPoint(mousePosition);
         case InterectInstanceType.Canvas:
            return mousePosition;
         default:
            return Vector2.zero;
      }
   }
}
