using Game_Event.EventArguments;
using Interface;
using Player.Graphics;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Utility.Extension;
using Utility.System.Publisher_Subscriber_System;

namespace Player.Collider
{
    public class PlayerColliderController : MonoBehaviour
    {
        #pragma warning disable 649
        [SerializeField] private PlayerGraphicsController playerGraphicsController;
        #pragma warning restore 649
        
        private SphereCollider playerCollider;
        
        private void Start()
        {
            playerCollider = GetComponent<SphereCollider>();
            playerCollider.OnCollisionEnterAsObservable().Subscribe(collision =>
            {
                if (!collision.collider.GetComponent<IGetColor>(out var getColor)) return;
                if (getColor.GetColor() != playerGraphicsController.GetColor())
                {
                    PublisherSubscriber.Publish(GameEventType.LevelFailed);       
                }
            });
        }
    }
}
