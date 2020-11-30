using System;
using Enemy;
using UnityEngine;

namespace Level
{

    public class GameController : IGameController
    {
        public event Action OnGameStart;
        public event Action OnGameOver;
        public event Action OnLevelStart;
        public event Action OnChapterComplete;
        
        private readonly ILevelModel _levelModel;
        private readonly IEnemyModel _enemyModel;
        private readonly IPlayerModel _playerModel;
        private readonly ILevelConfigProvider _levelConfigProvider;

        public GameController(ILevelModel levelModel,
                                IEnemyModel enemyModel,
                                IPlayerModel playerModel,
                                ILevelConfigProvider levelConfigProvider)
                                
        {
            _levelModel = levelModel;
            _enemyModel = enemyModel;
            _playerModel = playerModel;
            _levelConfigProvider = levelConfigProvider;

            _enemyModel.OnEnemyDied += Victory;
            _playerModel.OnPlayerDied += Defeat;
        }

        public void StartGame()
        {
            var chapter = 0;
            var level = 0;
            
            StartLevel(chapter, level);
            
            OnGameStart?.Invoke();
        }

        private void StartLevel(int chapter, int level)
        {
            _levelModel.SetLevelParams(chapter, level);
            
            OnLevelStart?.Invoke();
        }

        private void Victory()
        {
            MoveToNextLevel();
        }

        private void MoveToNextLevel()
        {
            var level = _levelModel.CurrentLevelInChapter + 1;
            var chapter = _levelModel.CurrentChapter;
            
            if (level >= _levelModel.GetTotalLevels())
            {
                level = 0;
                chapter++;

                OnChapterComplete?.Invoke();
            }
            
            StartLevel(chapter, level);
        }

        private void Defeat()
        {
            OnGameOver?.Invoke();
        }
    }
}