using System;
using Data;
using Game_Event.Abstract;
using Game_Event.EventArguments;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utility.Manager.EventArgs;
using Utility.System.Publisher_Subscriber_System;
using Zenject;

public class GameManager : GameEventHandler
{
    #pragma warning disable 649
    [SerializeField] private GameObject playerCollider;
    #pragma warning restore 649
    
    public static GameData GameData;
    public static LevelData LevelData;

    private Subscription<InputEventArgs> inputEventSubscription;

    protected override void OnEnable()
    {
        base.OnEnable();

        inputEventSubscription = PublisherSubscriber.Subscribe<InputEventArgs>(InputEventHandler);
    }

    private void Start()
    {
        PublisherSubscriber.Publish(GameEventType.IntroGame);
    }

    [Inject]
    private void Construct(GameData game, LevelData level)
    {
        Debug.Log("GameManager Injection.");
        GameData = game;
        LevelData = level;
    }

    private void InputEventHandler(InputEventArgs inputEventArgs)
    {
        PublisherSubscriber.Publish(GameEventType.StartGame);
        PublisherSubscriber.Unsubscribe(inputEventSubscription);
    }
    
    public override void OnGameEvent(GameEventType gameEventType)
    {
        switch (gameEventType)
        {
            case GameEventType.IntroGame:
                LevelData.CreateLevel();
                break;
            case GameEventType.StartGame:
                //Do nothing
                break;
            case GameEventType.LevelFailed:
                playerCollider.SetActive(false);
                break;
            case GameEventType.ReloadLevel:
                //just reload
                SceneManager.LoadScene(0);
                break;
            case GameEventType.LevelCompleted:
                playerCollider.SetActive(false);
                LevelData.LevelCompleted();
                break;
            case GameEventType.NextLevel:
                //Update data
                GameData.currentLevel++;
                LevelData.DestroyLevel();
                
                //reload
                SceneManager.LoadScene(0);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(gameEventType), gameEventType, null);
        }
    }
}
