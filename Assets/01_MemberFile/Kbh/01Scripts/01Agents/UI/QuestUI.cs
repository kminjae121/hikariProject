using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestUI : BaseUI
{
   protected override void Initialize()
   {
      base.Initialize();
      transform.SetParent(null);
      DontDestroyOnLoad(gameObject);
   }



}
