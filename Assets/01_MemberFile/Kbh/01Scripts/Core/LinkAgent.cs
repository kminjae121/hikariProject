using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LinkAgent<T, R> : OperateAgent<T>
   where T : Enum
   where R : Enum
{
   public Dictionary<R, List<OperateAgent<R>>> _operateAgentListDictionary;

   public void AddAgent(R type, OperateAgent<R> agent)
   {
      _operateAgentListDictionary[type].Add(agent);
   }

   public void RemoveAgent(R type, OperateAgent<R> agent)
   {
      _operateAgentListDictionary[type].Remove(agent);
   }

   public void EnableMessage(R type, int count = 1)
   {
      List<OperateAgent<R>> agentList = _operateAgentListDictionary[type];

      for(int i = 0; i<agentList.Count; ++i)
      {
         agentList[i].Enable(count);
      }
   }

   public void DisableMessage(R type)
   {
      List<OperateAgent<R>> agentList = _operateAgentListDictionary[type];

      for (int i = 0; i < agentList.Count; ++i)
      {
         agentList[i].Disable();
      }
   }

   public void StopLoopMessage(R type)
   {
      List<OperateAgent<R>> agentList = _operateAgentListDictionary[type];

      for (int i = 0; i < agentList.Count; ++i)
      {
         agentList[i].StopLoop();
      }
   }


}
