using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GetByRay<T> : Get<T>
   where T : class, IData
{
   public float checkRadius = 2f;
   public LayerMask whatIsCheck;
   private int _hitCnt = 2;
   private RaycastHit2D[] _hits = null;

   protected override T Find()
   {
      if (_hits is null)
         _hits = new RaycastHit2D[_hitCnt];

      ContactFilter2D filter = new ContactFilter2D().NoFilter();
      filter.layerMask = whatIsCheck;
      filter.useLayerMask = true;

      int cnt = Physics2D.CircleCast
         (_trm.transform.position, checkRadius, Vector2.right, filter, _hits, 0);

      for(int i  =0; i<cnt; ++i)
      {
         if(_hits[i].collider.TryGetComponent<T>(out var component))
         {
            return component;
         }
      }

      return null;
   }
}
