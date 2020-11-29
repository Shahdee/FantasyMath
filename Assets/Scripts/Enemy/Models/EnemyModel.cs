using System;

namespace Enemy
{
    public class EnemyModel : IEnemyModel
    {
        public event Action OnEnemyDied;
        
        public int Lives => _lives;

        private int _lives;

        public EnemyModel()
        {
            
        }

        public void SetLives(int lives)
        {
            _lives = lives;
        }

        public void AddLives(int lives)
        {
            _lives += lives;
            _lives = Math.Max(0, _lives);
            
            if (_lives == 0)
                OnEnemyDied?.Invoke();
        }
    }
}