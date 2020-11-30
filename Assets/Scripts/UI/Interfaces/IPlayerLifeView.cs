using UnityEngine;

namespace UI
{
    public interface IPlayerLifeView
    {
        void SetParent(Transform parent);

        void Show(bool show);
    }
}