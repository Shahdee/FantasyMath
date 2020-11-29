using System;
using Enemy;
using Operations;
using Operations.Enums;
using Player;

namespace Level
{
    public class TurnController : ITurnController
    {
        private readonly ILevelModel _levelModel;
        private readonly IEnemyController _enemyController;
        private readonly IPlayerController _playerController;
        private readonly ILevelConfigProvider _levelConfigProvider;
        private readonly IOperationController _operationController;

        public TurnController(ILevelModel levelModel, 
                                IEnemyController enemyController,
                                IPlayerController playerController,
                                ILevelConfigProvider levelConfigProvider,
                                IOperationController operationController)
        {
            _levelModel = levelModel;
            _enemyController = enemyController;
            _playerController = playerController;
            _levelConfigProvider = levelConfigProvider;
            _operationController = operationController;
        }

        public void SendResults(int operand1, int operand2, EOperationType operationType, int result)
        {
            if (_operationController.CheckOperation(operand1, operand2, operationType, result))
            {
                var enemyDamage = _levelConfigProvider.GetEnemyDamage();
                _enemyController.ReceiveDamage(enemyDamage);
            }
            else
            {
                var playerDamagae = _levelConfigProvider.GetPlayerDamage();
                _playerController.ReceiveDamage(playerDamagae);
            }
        }
    }
}