using Obstacle.Class;
using Obstacle.Controller.Abstract;
using Obstacle.Type;
using UnityEngine;

namespace Obstacle.Controller
{
    [RequireComponent(typeof(Renderer))]
    public class PlayerObstacleController : ObstacleController
    {
        protected override void OnValidate()
        {
            obstacleType = ObstacleType.PlayerObstacle;
            
            base.OnValidate();
        }

        private void Start()
        {
            ColorChanger = new PlayerColorChanger();
            Control();
        }
        
        protected override void Control()
        {
            ColorChanger.ChangeColor(GetComponent<Renderer>());
        }
    }
}
