using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : Node<Empty>
{
   private Dictionary<int, List<IInterctable>> _interectObjectDictionary
      = new Dictionary<int, List<IInterctable>>();

   private IInterctable currentGrabedInterect = null;

   public override void Receive<N>(N child, bool activeSelf)
   {
      if(child.GetTrm().TryGetComponent(out IInterctable interect))
      {
         if (!_interectObjectDictionary.ContainsKey(interect.InterectOrder))
            _interectObjectDictionary[interect.InterectOrder] = new List<IInterctable>();

         _interectObjectDictionary[interect.InterectOrder]
            .Add(interect);


         interect.AuthIsCanGrab += HandleAuthCanGrab;
         interect.OnRelease += HandleRelease;
      }
   }

   private void HandleRelease()
   {
      currentGrabedInterect = null;
   }

   private bool HandleAuthCanGrab(IInterctable interect)
   {
      int interectOrder = interect.InterectOrder;
      foreach(var pair in _interectObjectDictionary)
      {
         if (pair.Key <= interectOrder) continue;
         foreach(var frontInterect in pair.Value)
         {
            if (frontInterect == interect) continue;

            bool isOverlapFront = false;

            switch (frontInterect.InstanceType)
            {
               case InterectInstanceType.World:
                  isOverlapFront = InterectNode.CastInterectInCanvas(frontInterect);
                  break;

               case InterectInstanceType.Canvas:
                  isOverlapFront = InterectNode.CastInterectInCanvas(frontInterect);
                  break;
            }

            if (isOverlapFront)
               return false;
         }
      }



      if (currentGrabedInterect is not null
         && currentGrabedInterect != interect
         && currentGrabedInterect.InterectOrder >= interectOrder)
      {
         bool isOverlapWithCurrent = false;

         switch (currentGrabedInterect.InstanceType)
         {
            case InterectInstanceType.World:
               isOverlapWithCurrent = InterectNode.CastInterectInWorld(currentGrabedInterect);
            break;

            case InterectInstanceType.Canvas:
               isOverlapWithCurrent = InterectNode.CastInterectInCanvas(currentGrabedInterect);
            break;
         }


         if (isOverlapWithCurrent)
            return false;
         else
            currentGrabedInterect.OnRelease?.Invoke();
      }


      currentGrabedInterect = interect;
      return true;
   }
}
