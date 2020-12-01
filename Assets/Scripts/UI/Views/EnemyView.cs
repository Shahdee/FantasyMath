using UnityEngine;

namespace UI
{
    public class EnemyView : MonoBehaviour, IEnemyView
    {
        public void SetParent(Transform parent)
        {
            transform.SetParent(parent);
            transform.localPosition = Vector3.zero;
        }

        public void DestroyEnemy()
        {
            Destroy(gameObject);
        }
    }
}