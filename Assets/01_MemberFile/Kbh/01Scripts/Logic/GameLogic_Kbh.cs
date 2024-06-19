using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic_Kbh : LinkAgent<GameMode, AgentType>
{
   private GameMode _currentGameMode;
   public GameMode CurrentGameMode => _currentGameMode;

   public override void Initialize(MonoBehaviour owner, YieldInstruction yieldInstruction, ILinkable<GameMode> parent = null)
   {
      base.Initialize(owner, yieldInstruction, parent);
   }

   public void SetMode(GameMode mode)
   {
      _currentGameMode = mode;

      switch (mode)
      {
         case GameMode.Disable:
            Disable();
            break;

         case GameMode.Enable:
            Enable(-1);
            break;

         case GameMode.Sleep:

            break;
      }
   }

   public void DoTutorial()
   {

   }

   public override void Run()
   {
      base.Run();
   }

   public override void Update()
   {
      base.Update();
   }

   public override void Sleep()
   {
      base.Sleep();
   }
}
