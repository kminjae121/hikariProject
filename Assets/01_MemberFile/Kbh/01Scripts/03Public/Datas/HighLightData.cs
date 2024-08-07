using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighLightData : Data, IHighLight
{
   [field: Space(20), Header("HighLight")]
   [field: SerializeField] public float ColorChangeDelay { get; set; } = 0.2f;
   [field: SerializeField] public Color NormalColor { get; set; }
   [field: SerializeField]
   public Dictionary<HighLightType, Color> HighLightColor { get; set; }
      = new Dictionary<HighLightType, Color>();
   [field: SerializeField] public SpriteRenderer HighLightRenderer { get; set; }
   [field: SerializeField] public HighLightType CurrentHighLightType { get; set; } = HighLightType.Normal;
   [SerializeField] private HighLightColorPair[] _hightLightColorPairs;

   public event Action<HighLightType> OnHighLight;

   public void GiveHighLight(HighLightType type, float time)
   {
      if (time <= 0) return;
      HighLightType previousType = CurrentHighLightType;
      OnHighLight?.Invoke(type);
      DOVirtual.DelayedCall(time, () =>
      {
         OnHighLight?.Invoke(previousType);
      });
   }

   private void Awake()
   {
      HighLightRenderer = GetComponent<SpriteRenderer>();

      foreach (var pair in _hightLightColorPairs)
      {
         HighLightColor[pair.type] = pair.color;
      }
   }
}
