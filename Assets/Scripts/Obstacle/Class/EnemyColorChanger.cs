using Data;
using Obstacle.Class.Abstract;
using UnityEngine;
using Zenject;

namespace Obstacle.Class
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class EnemyColorChanger : ColorChanger
    {
        public override void ChangeColor(Renderer renderer)
        {
            renderer.sharedMaterial = LevelData.EnemyColor;
        }
    }
}