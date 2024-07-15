using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
   Movable,
   Grab,
   Grabed
}

[System.Serializable]
public struct HighLightColorPair
{
   public HighLightType type;
   public Color color;
}


public class PlayerObjectData : Data, 
   IMovement, IInterctable, IFollowMovement
{
   [field: Space(20), Header("Movement")]
   [field: SerializeField] public bool CanMove { get; set; } = true;

   [field: SerializeField] public MoveType MoveType { get; set; }
   [field: SerializeField] public float ForceX { get; set; }
   [field: SerializeField] public LayerMask WhatIsBottom { get; set; }
   [field: SerializeField] public LayerMask WhatIsObstacle { get; set; }

   [field: SerializeField] public Rigidbody2D Rigid { get; set; }
   [field: SerializeField] public Collider2D Collider { get; set; }


   [field: Space(20), Header("FollowMovement")]
   [field: SerializeField] public bool UseFollowMove { get; set; }
   [field: SerializeField] public float FollowSpeed { get; set; } = 2f;
   [field: SerializeField] public Vector2 TargetPosition { get; set; }
   

   [field: Space(20), Header("Interect")]
   [field: SerializeField] public InterectInstanceType InstanceType { get; set; }
   [field: SerializeField] public int InterectOrder { get; set; }
   [field:Space(5)]
   [field: SerializeField] public Camera Main { get; set; }
   [field: SerializeField] public bool IsInterected { get; set; } = false;
   [field: SerializeField] public bool IsGrab { get; set; }

   public Action OnPointerEnter { get; set; }
   public Action OnPointerStay { get; set; }
   public Action OnPointerExit { get; set; }
   public Action OnRelease { get; set; }
   public Action OnGrabed { get; set; }

   public Func<IInterctable, bool> AuthIsCanGrab { get; set; }

   public event Action<float, ForceMode2D> OnJump;
   public void Jump(float force, ForceMode2D mode=ForceMode2D.Impulse)
      => OnJump?.Invoke(force, mode);

   public Transform GetTrm()
      => transform;

   public Vector3 MouseWorldPos()
      => Main.ScreenToWorldPoint(Input.mousePosition);

   private void Awake()
   {
      Rigid = GetComponent<Rigidbody2D>();
      Collider = GetComponent<Collider2D>();

      Main = Camera.main;
   }
}
