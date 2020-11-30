using System;

namespace Enemy
{
    public interface IEnemyController
    {
        event Action OnEnemyDamage;
        void ReceiveDamage(int damage);
    }
}