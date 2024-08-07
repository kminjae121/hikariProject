using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface IPositionInit
{
   void Initialize(Vector2 position);
}

public interface IUIControl : IData
{
   bool IsActive { get; set; }
   Image ImageComponent { get; set; }
   void RemoveThis();

   RectTransform GetRect();
   void SetVisible(bool isActive);
}
