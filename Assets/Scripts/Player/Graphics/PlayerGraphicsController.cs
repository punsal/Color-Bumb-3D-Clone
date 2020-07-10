using Data;
using Game_Event.EventArguments;
using Game_Event.Interface;
using Interface;
using UnityEngine;
using Utility.System.Publisher_Subscriber_System;
using Zenject;

namespace Player.Graphics
{
    [RequireComponent(typeof(Renderer))]
    public class PlayerGraphicsController : MonoBehaviour, IGetColor, IGameEventHandler
    {
        #pragma warning disable 649
        [SerializeField] private TrailRenderer trailRenderer;
        #pragma warning restore 649
        
        private Renderer playerRenderer;

        private LevelData levelData;
        
        private Subscription<GameEventType> gameEventSubscription;
        
        private void Awake()
        {
            playerRenderer = GetComponent<Renderer>();
        }

        private void OnEnable()
        {
            gameEventSubscription = PublisherSubscriber.Subscribe<GameEventType>(OnGameEvent);
        }

        private void OnDisable()
        {
            PublisherSubscriber.Unsubscribe(gameEventSubscription);
        }

        [Inject]
        private void Construct(LevelData data)
        {
            levelData = data;
        }

        public Color GetColor() => playerRenderer.sharedMaterial.color;
        
        public void OnGameEvent(GameEventType gameEventType)
        {
            if (gameEventType == GameEventType.IntroGame)
            {
                SetColor(levelData.PlayerColor);
            }
        }

        private void SetColor(Material colorMaterial)
        {
            playerRenderer.sharedMaterial = colorMaterial;
            trailRenderer.material = colorMaterial;
        }
    }
}