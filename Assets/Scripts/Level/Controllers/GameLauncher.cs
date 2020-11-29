using System;
using Initialization;

namespace Level
{
    public class GameLauncher : IGameLauncher, IDisposable
    {
        
        private readonly ILevelConfigProvider _configProvider;
        private readonly IInitializeMediator _initializeMediator;
        private readonly ILevelModel _levelModel;
        private readonly IGameController _gameController;


        public GameLauncher(ILevelConfigProvider configProvider,
                            IInitializeMediator initializeMediator,
                            ILevelModel levelModel,
                            IGameController gameController)
        {
            _configProvider = configProvider;
            _initializeMediator = initializeMediator;
            _levelModel = levelModel;
            _gameController = gameController;

            _initializeMediator.OnDone += InitializeMediatorDone;
        }
        
        // TODO - player prefs 

        private void InitializeMediatorDone()
        {
            var data = _configProvider.GetLevelConfigData();
            _levelModel.SetChapterData(data.Chapter);
        }

        public void LaunchGame()
        {
            _gameController.StartGame();
        }

        public void LaunchGame(int chapter)
        {
            _gameController.StartGame();
        }
        
        public void Dispose()
        {
            _initializeMediator.OnDone -= InitializeMediatorDone;
        }
    }
}