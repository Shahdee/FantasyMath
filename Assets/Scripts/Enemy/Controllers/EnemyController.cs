using System;
using Level;

namespace Enemy
{
    public class EnemyController : IEnemyController, IDisposable
    {
        private readonly IEnemyModel _enemyModel;
        private readonly ILevelModel _levelModel;
        private readonly IGameController _gameController;
        private readonly ILevelConfigProvider _levelConfigProvider;
        private readonly IEnemyFactory _enemyFactory;

        public EnemyController(IEnemyModel enemyModel, 
                            ILevelModel levelModel,
                            IGameController gameController,
                            ILevelConfigProvider levelConfigProvider,
                            IEnemyFactory enemyFactory)
        {
            _enemyModel = enemyModel;
            _levelModel = levelModel;
            _gameController = gameController;
            _levelConfigProvider = levelConfigProvider;
            _enemyFactory = enemyFactory;

            _gameController.OnLevelStart += LevelStart;
        }

        public void ReceiveDamage(int damage)
        {
            _enemyModel.AddLives(damage);
        }

        private void LevelStart()
        {
            var lives = _levelConfigProvider.GetEnemyLives();
            _enemyModel.SetLives(lives);
        }

        public void Dispose()
        {
            _gameController.OnLevelStart -= LevelStart;
        }
    }
}