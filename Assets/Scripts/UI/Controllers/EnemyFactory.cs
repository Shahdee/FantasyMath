using UnityEngine;

namespace UI
{
    public class EnemyFactory : IEnemyFactory
    {
        private readonly EnemyView _normalEnemy;
        private readonly EnemyView _bossEnemy;

        private Transform _enemyParent;

        public EnemyFactory(EnemyView normalEnemy,
                            EnemyView bossEnemy)
        {
            _normalEnemy = normalEnemy;
            _bossEnemy = bossEnemy;
            
            _enemyParent = new GameObject().transform;
            _enemyParent.transform.position = Vector3.zero;
            _enemyParent.name = "enemyParent";
        }

        public IEnemyView CreateEnemy(bool boss)
        {
            EnemyView enemy;
            
            if (boss)
                enemy = Object.Instantiate(_bossEnemy);
            else
                enemy = Object.Instantiate(_normalEnemy);
            
            enemy.SetParent(_enemyParent);

            return enemy;
        }
    }
}