using System;

namespace Enemy
{
    public interface IEnemyModel
    {
        int TotalLives { get; }
        int Lives { get; }
        event Action OnDied;
        event Action<int> OnLifeChange;
        
        void SetLives(int lives);
        void AddLives(int lives);
        bool IsAlive();
    }
}