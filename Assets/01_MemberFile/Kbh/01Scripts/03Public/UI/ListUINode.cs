using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IListUI<P,D> : IUIControl
   where P : ListUIItemData<D>
   where D : IData
{
   Vector2 StartPosition { get; set; }
   P Prefab { get; set; }
   int AddItem(D data);
   void RemoveItem(int idx);
}

public class ListUINode<Prefab, Data> : Node<INode>
   where Prefab : ListUIItemData<Data>
   where Data : IData
{
   [SerializeField] private GetWithPath<IListUI<Prefab, Data>> _ListUIGetter;
   public IListUI<Prefab, Data> ListInfo => _ListUIGetter.data;

   protected virtual void OnEnable()
   {
      _ListUIGetter.Initialize(transform);
      Initialize();
   }



}
