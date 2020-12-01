using System;
using UnityEngine;

namespace UI
{
    public class ScreenBlockerView : MonoBehaviour
    {
        private void Awake()
        {
            Show(false);
        }

        public void Show(bool show) => gameObject.SetActive(show);
    }
}