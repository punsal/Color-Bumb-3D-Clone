using Data;
using Obstacle.Class.Interface;
using UnityEngine;

namespace Obstacle.Class.Abstract
{
    public abstract class ColorChanger : IColorChanger
    {
        protected readonly LevelData LevelData;

        protected ColorChanger()
        {
            LevelData = GameManager.LevelData;
        }
        
        public abstract void ChangeColor(Renderer renderer);
    }
}