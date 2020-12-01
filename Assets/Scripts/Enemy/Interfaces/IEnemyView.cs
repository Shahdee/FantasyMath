using UnityEngine;

namespace Enemy
{
    public interface IEnemyView
    {
        void SetParent(Transform parent);

        void DestroyEnemy();
    }
}