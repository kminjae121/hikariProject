using UnityEngine;


/// <summary>
/// 얘는 상속으로 갈기갈기 쪼개야 할 듯
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class Get<T>
   where T : class, IData
{
   protected Transform _trm = null;
   [SerializeField] protected string _path = string.Empty;
   [SerializeField] public T shell = null;

   public void Initialize(Transform trm)
   {
      _trm = trm;
      TryInitComponent();
   }

      public void TryInitComponent()
      => shell = Find();

   protected abstract T Find();
}
