using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct QuestInfo : IData
{

}

public class QuestListUI : ListUINode<QuestUIItemData, QuestInfo>
{
   protected override void OnEnable()
   {
      base.OnEnable();
      ListInfo.AddItem(default);
      ListInfo.AddItem(default);
      ListInfo.AddItem(default);
   }

   protected override void Update()
   {
      base.Update();
   }
}
