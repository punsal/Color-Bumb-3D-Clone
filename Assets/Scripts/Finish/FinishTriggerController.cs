using Game_Event.EventArguments;
using UnityEngine;
using Utility.Behaviour.Trigger;
using Utility.System.Publisher_Subscriber_System;

namespace Finish
{
    public class FinishTriggerController : TriggerController
    {
        protected override void OnTriggerEnterAction(Collider other)
        {
            PublisherSubscriber.Publish(GameEventType.LevelCompleted);
        }
    }
}
