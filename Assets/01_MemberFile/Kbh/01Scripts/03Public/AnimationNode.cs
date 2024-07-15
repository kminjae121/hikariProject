using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAnimation : IData
{
   Animator Animator { get; set; }
   string defaultAnim { get; set; }
   int CurrentAnimHash { get; set; }
   event Action<int> OnChangeAnimation;
}

public class AnimationNode : Node<INode>
{
   [SerializeField] private GetWithPath<IAnimation> _animationDataFinder;
   public IAnimation AnimationData => _animationDataFinder.data;

   private void OnEnable()
   {
      _animationDataFinder.Initialize(transform);

      AnimationData.OnChangeAnimation += HandleChangeAnimation;

      AnimationData.CurrentAnimHash = Animator.StringToHash(AnimationData.defaultAnim);
      AnimationData.Animator.SetBool(AnimationData.CurrentAnimHash, true);

      Initialize();
   }

   private void HandleChangeAnimation(int hash)
   {
      if (AnimationData.CurrentAnimHash == hash) return;
      AnimationData.Animator.SetBool(AnimationData.CurrentAnimHash, false);
      AnimationData.Animator.SetBool(hash, true);
      AnimationData.CurrentAnimHash = hash;
   }
}
