using System;
using Level;

namespace Enemy
{
    public class EnemyController : IEnemyController, IDisposable
    {
        private readonly IEnemyModel _enemyModel;
        private readonly ILevelModel _levelModel;
        private readonly ILevelController _gameController;
        private readonly ILevelConfigProvider _levelConfigProvider;

        public EnemyController(IEnemyModel enemyModel, 
                            ILevelModel levelModel,
                            ILevelController gameController,
                            ILevelConfigProvider levelConfigProvider)
        {
            _enemyModel = enemyModel;
            _levelModel = levelModel;
            _gameController = gameController;
            _levelConfigProvider = levelConfigProvider;

            _gameController.OnGameRelaunch += GameRelaunch;
            _gameController.OnLevelStart += LevelStart;
        }

        public void ReceiveDamage(int damage)
        {
            _enemyModel.AddLives(-damage);
        }

        private void GameRelaunch()
        {
            // RemoveEnemy();
        }

        private void LevelStart()
        {
            var lives = _levelConfigProvider.GetEnemyLives();
            _enemyModel.SetLives(lives);
        }

        // private void CreateEnemy()
        // {
        //     RemoveEnemy();
        //     _enemyView = _enemyFactory.CreateEnemy(_levelModel.IsBossLevel());
        // }

        // private void RemoveEnemy()
        // {
        //     if (_enemyView != null)
        //     {
        //         _enemyView.DestroyEnemy();
        //         _enemyView = null;
        //     }
        // }

        public void Dispose()
        {
            _gameController.OnGameRelaunch -= GameRelaunch;
            _gameController.OnLevelStart -= LevelStart;
        }
    }
}