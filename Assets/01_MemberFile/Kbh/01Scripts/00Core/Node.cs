using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface INode
{
   void Receive<T>(T child, bool activeSelf)
      where T : class, INode;
   void SetActive(bool activeSelf);
   Transform GetTrm();

   event Action OnUpdateEvt;
}

public abstract class Empty : INode
{
   public Transform GetTrm() => null;
   public abstract void SetActive(bool activeSelf);
   public abstract void Receive<T>(T child, bool activeSelf) where T : class, INode;
   public event Action OnUpdateEvt = null;
}


public abstract class Node<T> : MonoBehaviour, INode
   where T : class, INode
{
   protected T _parent = null;
   protected bool _isActive = false;

   public event Action OnUpdateEvt = null;
   
   protected virtual void Initialize()
   {
      if (typeof(T) == typeof(Empty)) return;
      if(TryFindParentNode(out var parent))
      {
         _parent = parent;
         SetActive(true);
      }
      else
      {
         Debug.LogError($@"ERROR :: There is no parent node 
for [{gameObject.name}]. Please Check. ");
      }
   }

   public Transform GetTrm() => transform;

   private bool TryFindParentNode(out T result)
   {
      result = null;

      Transform root = transform.root;
      Transform trm = transform;

      bool success = false;
      while(!success)
      {
         if(trm.parent.TryGetComponent<T>(out var component))
         {
            success = true;
            result = component;
            break;
         }

         if (trm == root) break;

         trm = transform.parent;
      }
      
      return success;
   }

   private void Send()
      => _parent.Receive(this, _isActive);

   public virtual void SetActive(bool activeSelf)
   {
      if (_isActive != activeSelf)
      {
         _isActive = activeSelf;

         if (_isActive)
            TurnOn();
         else
            TurnOff();

         Send();
      }
   }

   protected virtual void Update()
      => OnUpdateEvt?.Invoke();

   protected virtual void TurnOn() { }
   protected virtual void TurnOff() { }

   public virtual void Receive<N>(N child, bool activeSelf)
      where N : class, INode{}
}
