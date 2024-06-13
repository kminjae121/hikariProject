using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player_Kbh : LinkAgent<AgentType, PlayerState>
{
   [SerializeField] private StateMachine<PlayerState> _playerStateMachine;

   private GameObject playerGameObject;
   private Agent_Kbh playerAgent;

   public override void Initialize(MonoBehaviour owner, YieldInstruction yieldInstruction, ILinkable<AgentType> parent = null)
   {
      base.Initialize(owner, yieldInstruction, parent);

      _playerStateMachine.Initialize(owner, PlayerState.Idle);

      playerAgent = owner as Agent_Kbh;
      playerGameObject = playerAgent.gameObject;
   }

   public override void Run()
   {
      base.Run();
      playerGameObject.SetActive(true);
   }

   public override void Sleep()
   {
      playerGameObject.SetActive(false);
      base.Sleep();
   }

   public override void Update()
   {
      base.Update();
      _playerStateMachine.Update();
   }
}
