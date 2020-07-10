using Game_Event.Abstract;
using Game_Event.EventArguments;
using UnityEngine;
using Utility.Manager.EventArgs;
using Utility.System.Publisher_Subscriber_System;

namespace Player.Movement
{
    public class PlayerMovementController : GameEventHandler
    {
        #pragma warning disable 649
        [SerializeField] private Transform parentTransform;
        [SerializeField] private MovementConstraintsData movementConstraintsData;
        [SerializeField] private float speed = 10f;
        #pragma warning restore 649

        private Rigidbody playerRigidbody;
        
        private Subscription<InputEventArgs> inputEventSubscription;

        private void Awake()
        {
            playerRigidbody = GetComponent<Rigidbody>();
        }

        public override void OnGameEvent(GameEventType gameEventType)
        {
            if (gameEventType == GameEventType.StartGame)
            {
                SubscribeToInput();
            }

            if (gameEventType == GameEventType.LevelCompleted)
            {
                UnsubscribeToInput();
            }

            if (gameEventType == GameEventType.LevelFailed)
            {
                UnsubscribeToInput();
            }
        }

        private void SubscribeToInput()
        {
            inputEventSubscription = PublisherSubscriber.Subscribe<InputEventArgs>(InputEventHandler);
        }

        private void UnsubscribeToInput()
        {
            PublisherSubscriber.Unsubscribe(inputEventSubscription);
        }

        private void InputEventHandler(InputEventArgs inputEventArgs)
        {
            var currentPosition = playerRigidbody.transform.localPosition;
            
            var nextHorizontalPosition = currentPosition.x + inputEventArgs.Delta.x * Time.deltaTime * speed;
            var nextVerticalPosition = currentPosition.z + inputEventArgs.Delta.y * Time.deltaTime * speed;

            var nextPosition = new Vector3(
                movementConstraintsData.horizontalBorder.IsBetweenBorders(nextHorizontalPosition) 
                    ? nextHorizontalPosition 
                    : currentPosition.x,
                currentPosition.y,
                movementConstraintsData.verticalBorder.IsBetweenBorders(nextVerticalPosition) 
                    ? nextVerticalPosition 
                    : currentPosition.z
            );
            
            playerRigidbody.transform.localPosition = nextPosition;
        }
    }
}
