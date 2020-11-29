using System;

namespace Enemy
{
    public interface IEnemyModel
    {
        event Action OnEnemyDied;
        
        void SetLives(int lives);
        void AddLives(int lives);
    }
}