using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum InterectInstanceType
{
   World,
   Canvas,
}

public interface IInterctable : IData
{
   InterectInstanceType InstanceType { get; set; }
   int InterectOrder { get; set; }
   
   Collider2D Collider { get; set; }
   Camera Main { get; set; }
   bool IsInterected { get; set; }
   bool IsGrab { get; set; }

   Func<IInterctable, bool> AuthIsCanGrab { get; set; }
   Action OnPointerEnter { get; set; }
   Action OnPointerStay { get; set; }
   Action OnPointerExit { get; set; }
   Action OnGrabed { get; set; }
   Action OnRelease { get; set; }
   Transform GetTrm();
}


public class InterectNode : Node<INode>
{
   [SerializeField] private GetWithPath<IInterctable> interect;
   public IInterctable InterectInfo => interect.data;

   private static PointerEventData _eventData;
   private static List<RaycastResult> _raycastResult;

   private void Awake()
   {
      if (_eventData is null)
      {
         _eventData = new PointerEventData(EventSystem.current);
         _raycastResult = new List<RaycastResult>();
      }
   }

   private void OnEnable()
   {
      interect.Initialize(transform);
      Initialize();
   }

   protected override void Update()
   {
      if (!_isActive) return;
      base.Update();

      bool canGrab = InterectInfo.AuthIsCanGrab?.Invoke(InterectInfo) ?? false;
      if (!canGrab)
      {
         if (InterectInfo.IsGrab)
         {
            InterectInfo.OnRelease?.Invoke();
            InterectInfo.IsGrab = false;
         }
      }

      Vector2 mouseWorldPos
         = InterectInfo.Main.ScreenToWorldPoint(Input.mousePosition);

      bool previousInterected = InterectInfo.IsInterected;
      bool currentInterected = previousInterected;
      switch (InterectInfo.InstanceType)
      {
         case InterectInstanceType.World:
            currentInterected = CastInterectInWorld(InterectInfo);
            break;

         case InterectInstanceType.Canvas:
            currentInterected = CastInterectInCanvas(InterectInfo);
            break;
      }


      if (canGrab)
      {
         if(!previousInterected && currentInterected)
         {
            InterectInfo.OnPointerEnter?.Invoke();
}
         else if (previousInterected && currentInterected)
         {
            InterectInfo.OnPointerStay?.Invoke();
         }
         else if (previousInterected && !currentInterected)
         {
            InterectInfo.OnPointerExit?.Invoke();
         }

         if (currentInterected && Input.GetButtonDown("Fire1"))
         {
            InterectInfo.OnGrabed?.Invoke();
            InterectInfo.IsGrab = true;
         }
      }

      if(Input.GetButtonUp("Fire1") && InterectInfo.IsGrab)
      {
         InterectInfo.OnRelease?.Invoke();
         InterectInfo.IsGrab = false;
      }

      InterectInfo.IsInterected = currentInterected;
   }



   public static bool CastInterectInWorld(IInterctable interect)
   {
      return interect.Collider
         .OverlapPoint(interect.Main.ScreenToWorldPoint(Input.mousePosition));
   }

   public static bool CastInterectInCanvas(IInterctable interect)
   {
      _eventData.position = Input.mousePosition;
      EventSystem.current.RaycastAll(_eventData, _raycastResult);

      if (_raycastResult.Count > 0)
      {
         foreach(var castValue in _raycastResult)
         {
            if(castValue.isValid
               && castValue.gameObject == interect.GetTrm().gameObject)
            {
               return true;
            }
         }
      }
      return false;
   }

}
