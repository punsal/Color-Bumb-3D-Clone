using Game_Event.Abstract;
using Game_Event.EventArguments;
using UI.Controller;
using UnityEngine;
using Utility.System.Publisher_Subscriber_System;
using Utility.UI.Progress_Bar.Data;
using Utility.UI.Progress_Bar.Type;

namespace UI
{
    public class UIManager : GameEventHandler
    {
        #region UI Controllers

        private UIController[] uiControllers;

        #endregion
        
        #region ProgressBar Fields

        private ProgressBarData levelProgressBarData;
        private float totalLevelDistance;
        private float currentLevelDistance;
        private bool isTotalLevelDistanceCalculated;
        private bool isLevelCompleted;

        #endregion

        #region Delegates

        public delegate float GetPlayerPosition();

        public delegate float GetFinishPosition();

        #endregion

        #region Events

        public static event GetPlayerPosition OnGetPlayerPosition;

        public static event GetFinishPosition OnGetFinishPosition;

        #endregion

        #region UnityEngine Callbacks

        private void Awake()
        {
            uiControllers = FindObjectsOfType<UIController>();
        }

        private void Update()
        {
            UpdateLevelProgressBar(isLevelCompleted);
        }

        #endregion

        public override void OnGameEvent(GameEventType gameEventType)
        {
            UpdateUI(gameEventType);
            
            if (gameEventType == GameEventType.StartGame)
            {
                isLevelCompleted = false;
                InitializeLevelProgressBar();
            }
        
            if (gameEventType == GameEventType.LevelCompleted)
            {
                isLevelCompleted = true;
            }
        }

        private void UpdateUI(GameEventType gameEventType)
        {
            foreach (var uiController in uiControllers)
            {
                uiController.gameObject.SetActive(uiController.Type() == gameEventType);
            }
        }
        
        #region ProgressBar Methods

        private static float TryPlayerPosition()
        {
            var playerPosition = OnGetPlayerPosition?.Invoke();
            if (playerPosition != null) return (float) playerPosition;
            Debug.Log("Player Position is null");
            playerPosition = 0f;

            return (float) playerPosition;
        }

        private float TryFinishPosition()
        {
            var finishPosition = OnGetFinishPosition?.Invoke();
            if (finishPosition == null)
            {
                Debug.Log("Finish Position is null");
                isTotalLevelDistanceCalculated = false;
                finishPosition = 1f;
            }
            else
            {
                isTotalLevelDistanceCalculated = true;
            }

            return (float) finishPosition;
        }

        private void InitializeLevelProgressBar()
        {
            var playerPosition = TryPlayerPosition();

            var finishPosition = TryFinishPosition();

            totalLevelDistance = Mathf.Abs(playerPosition - finishPosition);
            currentLevelDistance = 0f;

            levelProgressBarData = new ProgressBarData
            {
                BarType = ProgressBarType.LevelProgression,
                TotalAmount = totalLevelDistance
            };
        }

        private void UpdateLevelProgressBar(bool isFilled = false)
        {
            var playerPosition = TryPlayerPosition();

            var finishPosition = TryFinishPosition();
            
            if (!isTotalLevelDistanceCalculated)
            {
                totalLevelDistance = Mathf.Abs(playerPosition - finishPosition);
                
                levelProgressBarData.TotalAmount = totalLevelDistance;
            }
            
            currentLevelDistance = isFilled
                ? totalLevelDistance
                : totalLevelDistance - Mathf.Abs(playerPosition - finishPosition);

            levelProgressBarData.CurrentAmount = currentLevelDistance;
            PublisherSubscriber.Publish(levelProgressBarData);
        }

        #endregion
    }
}
