using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastData : MonoBehaviour, IRayCast
{
   [field: SerializeField] public Vector2 Dir { get; set; }
   [field: SerializeField] public float Distance { get; set; }
   [field: SerializeField] public LayerMask WhatIsTarget { get; set; }

   public event Func<bool> OnCast;

   public Transform GetTrm()
      => transform;
   public bool Cast()
      => OnCast?.Invoke() ?? false;

#if UNITY_EDITOR

   private void OnDrawGizmosSelected()
   {
      Gizmos.color = Color.red;

      Gizmos.DrawWireSphere(GetTrm().position, 0.1f);
      Gizmos.DrawLine(
         from : GetTrm().position, 
         to : GetTrm().position + (Vector3)Dir * Distance);

      Gizmos.color = Color.white;
   }

#endif
}
