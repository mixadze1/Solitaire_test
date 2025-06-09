using _Scripts.CardLogic;
using _Scripts.GameLogic;
using UnityEngine;
using Zenject;

namespace _Scripts.Installers.GameInstaller
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private GameConfig _gameConfig; 
        [SerializeField] private SpotsController _spotsController;

        public override void InstallBindings()
        {
            Container.Bind<SpotsController>().FromInstance(_spotsController);
            Container.Bind<GameConfig>().FromInstance(_gameConfig);
        }
    }
}
