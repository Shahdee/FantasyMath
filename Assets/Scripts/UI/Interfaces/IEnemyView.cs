using UnityEngine;

namespace UI
{
    public interface IEnemyView
    {
        void SetParent(Transform parent);

        void DestroyEnemy();
    }
}