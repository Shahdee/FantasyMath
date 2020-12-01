using System;
using Level;
using UnityEngine;

namespace Player
{
    public class PlayerController : IPlayerController, IDisposable
    {
        private readonly IPlayerModel _playerModel;
        private readonly ILevelConfigProvider _levelConfigProvider;
        private readonly ILevelController _gameController;

        public PlayerController(IPlayerModel playerModel,
                                ILevelConfigProvider levelConfigProvider,
                                ILevelController gameController)
        {
            _playerModel = playerModel;
            _levelConfigProvider = levelConfigProvider;
            _gameController = gameController;

            _gameController.OnChapterComplete += ChapterComplete;
            _gameController.OnGameStart += GameStart;
        }
        
        public void ReceiveDamage(int damage)
        {
            Debug.Log("player receives damage " + damage);
            _playerModel.AddLives(-damage);
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