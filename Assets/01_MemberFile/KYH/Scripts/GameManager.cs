using DG.Tweening;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
   private void Awake()
   {
      IDOTweenInit dotweenInit = DOTween.Init(true, true, LogBehaviour.Verbose);
      dotweenInit.SetCapacity(50, 50);
   }

}
