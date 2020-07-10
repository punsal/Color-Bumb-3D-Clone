using System.Collections;
using Game_Event.Abstract;
using Game_Event.EventArguments;
using UnityEngine;

namespace Player.Pivot
{
    public class PlayerPivot : GameEventHandler
    {
        [SerializeField] private float speed = 20f;
        [SerializeField] private float stopDuration = 1f;

        private Rigidbody playerPivotRigidbody;

        protected override void OnEnable()
        {
            base.OnEnable();

            playerPivotRigidbody = GetComponent<Rigidbody>();
        }

        public override void OnGameEvent(GameEventType gameEventType)
        {
            if (gameEventType == GameEventType.StartGame)
            {
                Move();
            }

            if (gameEventType == GameEventType.LevelCompleted)
            {
                StartCoroutine(Stop());
            }

            if (gameEventType == GameEventType.LevelFailed)
            {
                StopImmediately();
            }
        }

        private void Move()
        {
            playerPivotRigidbody.isKinematic = false;
            playerPivotRigidbody.velocity = Vector3.forward * speed;
            playerPivotRigidbody.angularVelocity = Vector3.zero;
        }

        private IEnumerator Stop()
        {
            var currentVelocity = playerPivotRigidbody.velocity;
            
            var timer = 0f;
            var wait = new WaitForSeconds(Time.deltaTime);
            while (timer <= stopDuration)
            {
                var nextVelocity = Vector3.Lerp(currentVelocity, Vector3.zero, timer);
                playerPivotRigidbody.velocity = nextVelocity;

                yield return wait;
                
                timer += Time.deltaTime;
            }
            
            playerPivotRigidbody.velocity = Vector3.zero;
            playerPivotRigidbody.angularVelocity = Vector3.zero;
            playerPivotRigidbody.isKinematic = true;
        }

        private void StopImmediately()
        {
            playerPivotRigidbody.velocity = Vector3.zero;
            playerPivotRigidbody.angularVelocity = Vector3.zero;
            playerPivotRigidbody.isKinematic = true;
        }
    }
}
