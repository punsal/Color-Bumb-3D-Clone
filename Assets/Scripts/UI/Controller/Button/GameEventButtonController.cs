using Game_Event.EventArguments;
using UnityEngine;
using UnityEngine.UI;
using Utility.System.Publisher_Subscriber_System;

namespace UI.Controller
{
    [RequireComponent(typeof(Button))]
    public class GameEventButtonController : MonoBehaviour
    {
        #pragma warning disable 649
        [SerializeField] private GameEventType gameEventType;
        #pragma warning restore 649

        private Button button;

        private void OnEnable()
        {
            button = GetComponent<Button>();
     
            button.onClick.AddListener(SendGameEvent);
        }

        private void OnDisable()
        {
            button.onClick.RemoveListener(SendGameEvent);
        }

        private void SendGameEvent()
        {
            PublisherSubscriber.Publish(gameEventType);
        }
    }
}