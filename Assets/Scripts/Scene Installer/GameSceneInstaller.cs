using Data;
using Obstacle.Class;
using Obstacle.Class.Interface;
using Obstacle.Type;
using UnityEngine;
using Zenject;

namespace Scene_Installer
{
    public class GameSceneInstaller : MonoInstaller
    {
        #pragma warning disable 649
        [SerializeField] private GameData gameData;
        [SerializeField] private LevelData levelData;
        #pragma warning restore 649
        
        public override void InstallBindings()
        {
            Container.Bind<GameData>().FromScriptableObject(gameData).AsCached();
            Container.Bind<LevelData>().FromScriptableObject(levelData).AsCached();

            Container.Bind<IColorChanger>()
                .WithId(ObstacleType.EnemyObstacle)
                .To<EnemyColorChanger>()
                .FromNew()
                .AsCached();

            Container.Bind<IColorChanger>()
                .WithId(ObstacleType.PlayerObstacle)
                .To<PlayerColorChanger>()
                .FromNew()
                .AsCached();
        }
    }
}