using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFollowMovement : IData
{
   public bool UseFollowMove { get; set; }
   public float FollowSpeed { get; set; }
   public Vector2 TargetPosition { get; set; }
   public Rigidbody2D Rigid { get; set; }
   public Collider2D Collider { get; set; }
   public Transform GetTrm();
}

public class FollowMoveNode : Node<INode>
{
   [SerializeField] private GetWithPath<IFollowMovement> _followMovement;
   public IFollowMovement followMoveInfo => _followMovement.data;

   private void OnEnable()
   {
      _followMovement.Initialize(transform);
      Initialize();
   }

   protected override void Update()
   {
      if (!_isActive) return;
      base.Update();

      if (followMoveInfo.UseFollowMove)
      {
         Vector2 dir = followMoveInfo.TargetPosition
            - (Vector2)followMoveInfo.GetTrm().position;

         followMoveInfo.Collider.enabled = false;
         followMoveInfo.Rigid.velocity = followMoveInfo.FollowSpeed * dir;

         if (dir.sqrMagnitude == 0)
            followMoveInfo.GetTrm().position = followMoveInfo.TargetPosition;
      }
      else
      {
         followMoveInfo.Collider.enabled = true;
      }

   }

}
