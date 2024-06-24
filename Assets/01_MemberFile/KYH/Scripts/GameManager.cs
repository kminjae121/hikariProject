using DG.Tweening;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
   [Header("Debug")]
   [SerializeField] private GameLogic_Kbh _gameLogic;

   private void Awake()
   {
      IDOTweenInit dotweenInit = DOTween.Init(true, true, LogBehaviour.Verbose);
      dotweenInit.SetCapacity(50, 50);

      _gameLogic = transform.Find("GameLogic")
         .GetComponent<GameLogic_Kbh>();

      _gameLogic.Initialize();
   }

}
