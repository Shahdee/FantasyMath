using System;

namespace Player
{
    public class PlayerModel : IPlayerModel
    {
        public event Action OnPlayerDied;
        
        public int Lives => _lives;

        private int _lives;

        public PlayerModel()
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
                OnPlayerDied?.Invoke();
        }
    }
}