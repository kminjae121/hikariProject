using System;
using UnityEngine;

public enum MoveType
{
   Rigidbody,
   Transform
}

public interface IMovement : IData
{
   bool CanMove { get; set; }

   MoveType MoveType { get; set; }
   float ForceX { get; set; }
   LayerMask WhatIsBottom { get; set; }
   LayerMask WhatIsObstacle { get; set; }

   Rigidbody2D Rigid { get; set; }
   Collider2D Collider { get; set; }
   Transform GetTrm();

   event Action<float, ForceMode2D> OnJump;
}

public class PlatformMoveNode : Node<INode>
{
   [SerializeField] private GetWithPath<IMovement> movement;
   public IMovement movementInfo => movement.data;


   private void OnEnable()
   {
      movement.Initialize(transform);
      movementInfo.OnJump += HandleJump;
      Initialize();
   }

   private void HandleJump(float force, ForceMode2D forceMode = ForceMode2D.Impulse)
      => movementInfo.Rigid.AddForce(force * Vector2.up, forceMode);

   protected void FixedUpdate()
   {
      if (!_isActive) return;
      if (!movementInfo.CanMove) return;

      base.Update();

      switch (movementInfo.MoveType)
      {
         case MoveType.Rigidbody:
            movementInfo.Collider.enabled = true;

            movementInfo.Rigid.velocity
               = new Vector2(movementInfo.ForceX, movementInfo.Rigid.velocity.y);
            break;

         case MoveType.Transform:
            movementInfo.Collider.enabled = false;

            movementInfo.GetTrm().position
               += movementInfo.ForceX * Vector3.right * Time.deltaTime;
            break;
      }

      movementInfo.GetTrm().localScale
         = new Vector3(Mathf.Sign(movementInfo.ForceX), 1, 1);
   }


}
