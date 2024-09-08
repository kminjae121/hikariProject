using DG.Tweening;
using UnityEngine;
using System;

public class GameManager : MonoSingleton<GameManager>
{
    public static GameManager Instance;

    public Action OnClickDown;
    public Action OnClickUp;

   private void Awake()
   {
      IDOTweenInit dotweenInit = DOTween.Init(true, true, LogBehaviour.Verbose);
      dotweenInit.SetCapacity(50, 50);

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
   }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            OnClickDown?.Invoke();
        if (Input.GetMouseButtonUp(0))
            OnClickUp?.Invoke();
    }
}
