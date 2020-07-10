using System;
using Game_Event.EventArguments;
using UnityEngine;

namespace Utility.Behaviour.Game.HotKey
{
    [Serializable]
    public struct HotKeyData
    {
        public KeyCode keyCode;
        public GameEventType eventType;
    }
}