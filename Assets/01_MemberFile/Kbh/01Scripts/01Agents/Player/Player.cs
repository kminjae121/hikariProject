using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Node<Core>
{
   [Space, Header("==========Data=========="), Space]
   [SerializeField] private GetWithPath<PlayerObjectData> _dataGetter;
   private PlayerObjectData Obj => _dataGetter.data;

   [SerializeField] private GetWithPath<IPlayerStatus> _statusGetter;
   private IPlayerStatus Status => _statusGetter.data;

   [SerializeField] private GetWithPath<CastData> _groundCastGetter;
   private CastData GroundChecker => _groundCastGetter.data;

   [SerializeField] private GetWithPath<AnimationData> _animationGetter;
   private AnimationData Animation => _animationGetter.data;

   [SerializeField] private GetWithPath<HighLightData> _highLightGetter;
   private HighLightData HighLight => _highLightGetter.data;


   [Space, Header("==========Components=========="), Space]
   [SerializeField] private UsePlayerMove move;
   [SerializeField] private UsePlayerInterect interect;
   [SerializeField] private UsePlayerFollowMove followMove;
   [SerializeField] new private UsePlayerAnimation animation;



   private void Awake()
   {
      /* Data Load */
      _dataGetter.Initialize(transform);
      _statusGetter.Initialize(transform);
      _animationGetter.Initialize(transform);
      _highLightGetter.Initialize(transform);
      _groundCastGetter.Initialize(transform);


      /* Use Process */
      move.Initialize(this, (Status, Obj, GroundChecker));
      interect.Initialize(this, (Obj, Status));
      followMove.Initialize(this, (Obj, Status));
      animation.Initialize(this, (Obj, Status, Animation, GroundChecker));

      /* Init This */
      Initialize();

      /* Test */
      DOVirtual.DelayedCall(0.2f, () =>
      {
         HighLight.GiveHighLight(HighLightType.Error, 2f);
      });
   }

}
