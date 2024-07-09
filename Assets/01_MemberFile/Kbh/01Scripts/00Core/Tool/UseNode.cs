using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UseNode<Owner,T> 
   where Owner : class, INode
   where T : class, INode
{
   public Owner owner;
   public void Initialize(Owner owner)
   {
      this.owner = owner;
   }

   public void Check(INode value, bool activeSelf)
   {
      if (value is null || value is not T) return;

      if (activeSelf)
      {
         Registe();
      }
      else
      {
         DeRegiste();
      }
   }

   public abstract void DeRegiste();
   public abstract void Registe();
}
