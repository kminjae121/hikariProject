using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TutorialObject : MonoBehaviour
{
   [Flags]
   public enum TutorialEventEnum
   {
      Null = 0,
      Time = 1,
      Click = 2
   }

   public struct TutorialContentStruct
   {
      public TutorialEventEnum nextOverType;
      public UIBowl[] contents;
      public string text;
      public float delay;
   }

   [SerializeField] private TextMeshProUGUI _textDisplay;
   [SerializeField] private Button _selectGuideButton;

   [SerializeField] private TutorialContentStruct[] _tutorialContentList;

   private bool _isEnable = false;
   private int _currentContentIdx = 0;
   private TutorialContentStruct _previousContent;
   private TutorialContentStruct _currentContent;
   private bool _isWait = true;
   private float _lastTimeStamp;

   private void OnEnable()
   {
      _selectGuideButton.onClick.AddListener(HandleSelectGuideButtonClick);
      _previousContent = new TutorialContentStruct();
      _currentContent = _tutorialContentList[0];
      _isEnable = true;
   }

   private void HandleSelectGuideButtonClick()
   {
      if ((int)(_currentContent.nextOverType & TutorialEventEnum.Click) > 0)
      {
         _isWait = false;
      }
   }

   private void Update()
   {
      if (!_isEnable) return;

      if (_isWait)
      {
         CheckFlipNextContent();
      }
      else
      {
         FlipNextContent();
      }


   }

   private void FlipNextContent()
   {
      if(_previousContent.nextOverType != TutorialEventEnum.Null)
      {
         foreach(var content in _previousContent.contents)
         {
         }
      }
   }

   private void CheckFlipNextContent()
   {
      if ((_currentContent.nextOverType & TutorialEventEnum.Time) == 0) return;
      if (_lastTimeStamp + _currentContent.delay < Time.time)
      {
         _isWait = false;
         _lastTimeStamp = Time.time;
         _previousContent = _currentContent;

         _currentContentIdx++;

         while (_tutorialContentList[_currentContentIdx].nextOverType == TutorialEventEnum.Null
            && _currentContentIdx == _tutorialContentList.Length)
         {
            ++_currentContentIdx;
         }

         if (_currentContentIdx == _tutorialContentList.Length)
         {
            _isEnable = false;
            DisableAction();
            return;
         }

         _currentContent = _tutorialContentList[_currentContentIdx];
      }
   }

   private void DisableAction()
   {
   }

   private void OnDisable()
   {
      
   }


}
