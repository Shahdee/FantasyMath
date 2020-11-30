using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class PlayerLifeView : MonoBehaviour, IPlayerLifeView
    {
        [SerializeField] private Image _activeLife;
        [SerializeField] private Image _deactivatedLife;
        
        public void SetParent(Transform parent)
        {
            transform.SetParent(parent);
        }

        public void Show(bool show)
        {
            _activeLife.gameObject.SetActive(show);
            _deactivatedLife.gameObject.SetActive(!show);
        }
    }
}