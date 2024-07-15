using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;


public abstract class Parts<T> 
   where T : ITuple
{
   protected INode _owner;
   protected T _data;

   public void Initialize(INode owner, T data)
   {
      _owner = owner;
      _data = data;
      Start();
   }

   public abstract void Start();

   public virtual void Dispose()
   {
      _owner = null;
   }
   
}



public abstract class Part<T>
   where T : IData
{
   protected INode _owner;
   protected T _data;

   public void Initialize(INode owner, T data)
   {
      _owner = owner;
      _data = data;
      Start();
   }

   public abstract void Start();

   public virtual void Dispose()
   {
      _owner = null;
   }

}
