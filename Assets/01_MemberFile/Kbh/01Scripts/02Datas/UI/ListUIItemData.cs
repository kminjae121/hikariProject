using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class ListUIItemData<D> : Data, IUIControl, IPositionInit
      where D : IData
{
   [field: SerializeField] public Image ImageComponent { get; set; }
   [SerializeField] private float _fadeTime = 0.2f;
   public int idx = -1;

   [SerializeField] private bool _isActive = false;
   public bool IsActive
   {
      set
      {
         SetVisible(value);
         _isActive = value;
      }
      get => _isActive;
   }

   public event Action<IUIControl, int> OnRemove;

   public RectTransform GetRect()
      => transform as RectTransform;


   public void Initialize(Vector2 position)
   {
      IsActive = true;
      ImageComponent = GetComponent<Image>();
      ImageComponent.color = Color.clear;

      float xmoveAmount = -1000;
      transform.position += Vector3.right * xmoveAmount;
      transform.DOMoveX(-xmoveAmount, _fadeTime)
         .SetRelative();
   }

   public void Initialize(Vector2 position, int idx, D data)
   {
      FillData(data);
      Initialize(position);
      this.idx = idx;
   }

   public abstract void FillData(D data);

   public void RemoveThis()
   {
      SetVisible(false);

      float xmoveAmount = -1000;
      transform.DOMoveX(xmoveAmount, _fadeTime)
         .SetRelative();

      OnRemove?.Invoke(this, idx);
   }


   public void SetVisible(bool isActive)
   {
      _isActive = isActive;

      if (isActive)
         ImageComponent.DOFade(1f, _fadeTime);
      else
         ImageComponent.DOFade(0, _fadeTime);
   }

}
