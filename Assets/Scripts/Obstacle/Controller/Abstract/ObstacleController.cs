using Interface;
using Obstacle.Class.Interface;
using Obstacle.Type;
using UnityEngine;

namespace Obstacle.Controller.Abstract
{
    public abstract class ObstacleController : MonoBehaviour, IGetColor
    {
        [SerializeField] protected ObstacleType obstacleType = ObstacleType.PlayerObstacle;

        protected IColorChanger ColorChanger;
        
        protected virtual void OnValidate()
        {
            gameObject.name = obstacleType == ObstacleType.EnemyObstacle ? "Enemy" : "Obstacle";
            gameObject.layer = LayerMask.NameToLayer(obstacleType == ObstacleType.EnemyObstacle ? "Enemy" : "Default");
        }

        protected abstract void Control();

        public Color GetColor() => GetComponent<Renderer>().sharedMaterial.color;
    }
}