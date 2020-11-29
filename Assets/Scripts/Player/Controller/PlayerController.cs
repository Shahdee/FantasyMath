using System;
using Level;

namespace Player
{
    public class PlayerController : IPlayerController, IDisposable
    {
        private readonly IPlayerModel _playerModel;
        private readonly ILevelConfigProvider _levelConfigProvider;
        private readonly IGameController _gameController;

        public PlayerController(IPlayerModel playerModel,
                                ILevelConfigProvider levelConfigProvider,
                                IGameController gameController)
        {
            _playerModel = playerModel;
            _levelConfigProvider = levelConfigProvider;
            _gameController = gameController;

            _gameController.OnChapterComplete += ChapterComplete;
            _gameController.OnGameStart += GameStart;
        }
        
        public void ReceiveDamage(int damage)
        {
            _playerModel.AddLives(damage);
        }

        private void GameStart()
        {
            _playerModel.SetLives(_levelConfigProvider.GetPlayerLives()) ;
        }
        
        private void ChapterComplete()
        {
            _playerModel.SetLives(_levelConfigProvider.GetPlayerLives()) ;
        }

        public void Dispose()
        {
            _gameController.OnChapterComplete -= ChapterComplete;
            _gameController.OnGameStart -= GameStart;
        }
    }
}