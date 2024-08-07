using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationData : Data, IAnimation
{  
   [field: Space(20), Header("Animation")]
   [field: SerializeField] public Animator Animator { get; set; }
   [field: SerializeField] public string defaultAnim { get; set; }
   public int CurrentAnimHash { get; set; }

   public event Action<int> OnChangeAnimation;

   public void ChangeAnimation(int hash)
      => OnChangeAnimation?.Invoke(hash);

   private void Awake()
   {
      Animator = GetComponent<Animator>();
   }
}
