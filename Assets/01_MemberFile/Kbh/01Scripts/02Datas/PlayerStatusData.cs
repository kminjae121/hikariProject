using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerStatus : IData
{
   float Speed { get; set; }
   float FollowSpeed { get; set; }
   float JumpPower { get; set; }
   
   PlayerState State { get; set; }
}

public class PlayerStatusData : Data, IPlayerStatus
{
   [field: Space(20), Header("Status")]
   [field: SerializeField] public float Speed { get; set; } = 5f;
   [field: SerializeField] public float FollowSpeed { get; set; } = 2f;
   [field: SerializeField] public float JumpPower { get; set; } = 5f;

   [field: SerializeField] public PlayerState State { get; set; } = PlayerState.Movable;
}
