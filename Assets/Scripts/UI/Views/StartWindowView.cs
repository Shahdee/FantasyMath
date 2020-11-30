using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class StartWindowView : AbstractWindowView
    {
        public event Action OnPlay;
        
        [SerializeField] private Button _btnPlay;

        private void Awake()
        {
            _btnPlay.onClick.AddListener(()=>OnPlay?.Invoke());
        }
    }
}