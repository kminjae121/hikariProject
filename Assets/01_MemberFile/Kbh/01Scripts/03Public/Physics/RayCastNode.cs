using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRayCast : IData
{
   Vector2 Dir { get; set; }
   float Distance { get; set; }
   LayerMask WhatIsTarget { get; set; }
   Transform GetTrm();

   event Func<bool> OnCast;
}

public class RayCastNode : Node<INode>
{
   [SerializeField] private GetWithPath<IRayCast> _rayCastGetter;
   public IRayCast RayCastInfo => _rayCastGetter.data;

   private void OnEnable()
   {
      _rayCastGetter.Initialize(transform);
      RayCastInfo.OnCast += HandleCast;
      Initialize();
   }

   private bool HandleCast()
   {
      return  Physics2D.Raycast(
         origin: RayCastInfo.GetTrm().position,
         direction: RayCastInfo.Dir,
         distance: RayCastInfo.Distance,
         layerMask: RayCastInfo.WhatIsTarget);
   }
}
