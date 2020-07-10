using Game_Event.EventArguments;

namespace Game_Event.Interface
{
    public interface IGameEventHandler
    {
        void OnGameEvent(GameEventType gameEventType);
    }
}