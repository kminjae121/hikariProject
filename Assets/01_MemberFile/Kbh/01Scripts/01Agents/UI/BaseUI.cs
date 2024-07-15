using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUI : AbstractUI
{
   [Header("Datas")]
   [SerializeField] private GetWithPath<UIData> _uiDataGetter;
   private UIData UIData => _uiDataGetter.data;

   [Header("Components")]
   [SerializeField] private UseUIDragMove _dragMove;
      
   public virtual void Awake()
   {
      _uiDataGetter.Initialize(transform);
      _dragMove.Initialize(this, UIData);
      Initialize();
   }

   private void OnDestroy()
   {
      _dragMove.Dispose();
   }


}
