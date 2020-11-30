using UnityEngine;

namespace UI.Views
{
    public interface IWindowView
    {
        Transform ViewTransform { get; }

        void SetOrder(int order);

        void Show();

        void Hide();
    }
}