using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum HighLightType
{
   Normal,
   Warning,
   Error
}

public interface IHighLight : IData
{
   HighLightType CurrentHighLightType { get; set; }
   float ColorChangeDelay { get; set; }
   Color NormalColor { get; set; } 
   Dictionary<HighLightType, Color> HighLightColor { get; set; } 

   SpriteRenderer HighLightRenderer { get; set; } 

   event Action<HighLightType> OnHighLight;
}

public class HighLightNode : Node<INode>
{
   [SerializeField] private GetWithPath<IHighLight> _visual;
   public IHighLight VisualInfo => _visual.data;

   Tween _colorTween = null;

   private void OnEnable()
   {
      _visual.Initialize(transform);
      Initialize();

      VisualInfo.OnHighLight += HandleHighLight;
   }

   private void HandleHighLight(HighLightType type)
   {
      if (_colorTween is not null && _colorTween.active)
         _colorTween.Kill();

      Color targetColor = VisualInfo.HighLightColor[type];
      _colorTween = VisualInfo.HighLightRenderer.DOColor(targetColor, VisualInfo.ColorChangeDelay);
      VisualInfo.CurrentHighLightType = type;
   }
}
