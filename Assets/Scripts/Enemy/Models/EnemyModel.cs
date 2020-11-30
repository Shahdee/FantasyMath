using System;

namespace Enemy
{
    public class EnemyModel : IEnemyModel
    {
        public event Action OnDied;
        public event Action<int> OnLifeChange;
        public int Lives => _lives;
        public int TotalLives => _totalLives;

        private int _lives;
        private int _totalLives;

        public EnemyModel()
        {
            
        }

        public void SetLives(int lives)
        {
            _totalLives = _lives = lives;
            
            OnLifeChange?.Invoke(_lives);
        }

        public void AddLives(int lives)
        {
            _lives += lives;
            _lives = Math.Max(0, _lives);

            OnLifeChange?.Invoke(_lives);
            
            if (_lives == 0)
                OnDied?.Invoke();
        }

        public bool IsAlive()
        {
            return _lives > 0;
        }
    }
}