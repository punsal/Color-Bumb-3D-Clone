using Obstacle.Class.Abstract;
using UnityEngine;
using Zenject;

namespace Obstacle.Class
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class PlayerColorChanger : ColorChanger
    {
        public override void ChangeColor(Renderer renderer)
        {
            renderer.sharedMaterial = LevelData.PlayerColor;
        }
    }
}