using Obstacle.Class;
using Obstacle.Controller.Abstract;
using Obstacle.Type;
using UnityEngine;

namespace Obstacle.Controller
{
    [RequireComponent(typeof(Renderer))]
    public class EnemyObstacleController : ObstacleController
    {
        protected override void OnValidate()
        {
            obstacleType = ObstacleType.EnemyObstacle;
            
            base.OnValidate();
        }

        private void Start()
        {
            ColorChanger = new EnemyColorChanger();
        }

        protected override void Control()
        {
            ColorChanger.ChangeColor(GetComponent<Renderer>());
        }

    }
}