using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LogicManager_Kbh : MonoSingleton<LogicManager_Kbh>
{
   /// [필수 요소들]
   /// 
   /// 플레이어
   /// 플레이어 행동들
   /// 실행 파일 리스트
   /// 제어판 기능들
   /// 패널 셋팅
   /// 

   [SerializeField] private GameLogic_Kbh _logicAgent;

   private void Awake()
   {
      _logicAgent.Initialize(this, null, null);
   }

   public void DoTutorial()
   {

   }




}
