using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIData : Data, IInterctable
{
   [field: Header("Interect")]
   [field: SerializeField] public InterectInstanceType InstanceType { get; set; }
   [field: SerializeField] public int InterectOrder { get; set; }
   [field: SerializeField] public Collider2D Collider { get; set; }
   [field: SerializeField] public Camera Main { get; set; }
   [field: SerializeField] public bool IsInterected { get; set; }
   [field: SerializeField] public bool IsGrab { get; set; }
   public Func<IInterctable, bool> AuthIsCanGrab { get; set; }
   public Action OnPointerEnter { get; set; }
   public Action OnPointerStay { get; set; }
   public Action OnPointerExit { get; set; }
   public Action OnGrabed { get; set; }
   public Action OnRelease { get; set; }

   public Transform GetTrm() => transform;

   private void Awake()
   {
      if(InstanceType == InterectInstanceType.World)
         Collider = GetComponent<Collider2D>();
      Main = Camera.main;
   }
}
