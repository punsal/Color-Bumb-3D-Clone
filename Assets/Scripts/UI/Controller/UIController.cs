using Game_Event.EventArguments;
using UnityEngine;

namespace UI.Controller
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private GameEventType gameEventType = GameEventType.IntroGame;

        public GameEventType Type() => gameEventType;
    }
}
