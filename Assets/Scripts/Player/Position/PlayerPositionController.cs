using Game_Event.Abstract;
using Game_Event.EventArguments;
using UI;
using UnityEngine;

namespace Player
{
    public class PlayerPositionController : GameEventHandler
    {
        private Rigidbody playerRigidbody;

        protected override void OnEnable()
        {
            base.OnEnable();

            playerRigidbody = GetComponent<Rigidbody>();

            UIManager.OnGetPlayerPosition += OnGetPlayerPositionHandler;
        }

        protected override void OnDisable()
        {
            base.OnDisable();

            UIManager.OnGetPlayerPosition -= OnGetPlayerPositionHandler;
        }

        public override void OnGameEvent(GameEventType gameEventType)
        {
            if (gameEventType == GameEventType.LevelCompleted)
            {
                Stop();
            }
        }

        private float OnGetPlayerPositionHandler() => transform.position.z;

        private void Stop()
        {
            playerRigidbody.velocity = Vector3.zero;
            playerRigidbody.angularVelocity = Vector3.zero;
            playerRigidbody.isKinematic = true;
        }
    }
}