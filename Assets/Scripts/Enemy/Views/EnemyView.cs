using UnityEngine;

namespace Enemy
{
    public class EnemyView : MonoBehaviour, IEnemyView
    {
        public void SetParent(Transform parent)
        {
            transform.SetParent(parent);
        }

        public void DestroyEnemy()
        {
            Destroy(gameObject);
        }
    }
}