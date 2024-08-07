using DG.Tweening;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestUIData : UIData, IListUI<QuestUIItemData, QuestInfo>
{
   [field: SerializeField] public bool IsActive { get; set; }
   [field: SerializeField] public float FadeTime { get; set; } = 0.2f;
   [field: SerializeField] public Vector2 StartPosition { get; set; }
   [field: SerializeField] public Vector2 ItemGap { get; set; }
   [field: SerializeField] public Image ImageComponent { get; set; }
   [field:Space]
   [field: SerializeField] public QuestUIItemData Prefab { get; set; }

   private Dictionary<int, QuestUIItemData> _questUIItemDictionary
      = new Dictionary<int, QuestUIItemData>();

   private int _currentIdx = 0;
   private int _itemCounter = 0;

   public int AddItem(QuestInfo data)
   {
      QuestUIItemData questUIItem = Instantiate(Prefab);
      questUIItem.Initialize(Vector2.zero, _currentIdx, data);
      _questUIItemDictionary.Add(_itemCounter, questUIItem);

      ++_currentIdx;
      return ++_itemCounter;
   }

   public void RemoveItem(int hash)
   {
      if (_questUIItemDictionary.Remove(hash, out var removeValue))
      {
         removeValue.RemoveThis();
         foreach(var quest in _questUIItemDictionary)
         {
            if(removeValue.idx < quest.Value.idx)
            {
               quest.Value.idx--;
               quest.Value.transform.DOMove
                  (StartPosition + ItemGap * quest.Value.idx, FadeTime);
            }
         }
      }
   }

   public RectTransform GetRect() => transform as RectTransform;


   public void RemoveThis()
   {
      SetVisible(false);
      DOVirtual.DelayedCall(FadeTime,
      () =>
      {
         foreach(var quests in _questUIItemDictionary)
         {
            quests.Value.RemoveThis();
         }
      });
   }

   public void SetVisible(bool isActive)
   {
      int scaleX = IsActive ? 1 : 0;
      transform.DOScaleX(scaleX, FadeTime)
         .SetEase(Ease.InBounce);
   }


   public enum PlayerStateEnum
   {
      Idle,
      Move
   }


#if UNITY_EDITOR
   private void OnDrawGizmosSelected()
   {
      Vector2 itemDrawStartPosition = transform.position + (Vector3)StartPosition;
      float sphereRadius = 10f;
      Gizmos.color = Color.red;
      Gizmos.DrawSphere(itemDrawStartPosition, sphereRadius);
      Gizmos.color = Color.white;
   }
#endif


}
