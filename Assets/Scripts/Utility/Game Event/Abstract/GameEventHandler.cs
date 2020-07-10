using Game_Event.EventArguments;
using Game_Event.Interface;
using UnityEngine;
using Utility.System.Publisher_Subscriber_System;

namespace Game_Event.Abstract
{
    public abstract class GameEventHandler : MonoBehaviour, IGameEventHandler
    {
        private Subscription<GameEventType> gameEventSubscription;

        protected virtual void OnEnable()
        {
            gameEventSubscription = PublisherSubscriber.Subscribe<GameEventType>(OnGameEvent);
        }

        protected virtual void OnDisable()
        {
            PublisherSubscriber.Unsubscribe(gameEventSubscription);
        }

        public abstract void OnGameEvent(GameEventType gameEventType);
    }
}