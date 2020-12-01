using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class DefeatWindowView : AbstractWindowView
    {
        public event Action OnAcceptClick;
        
        [SerializeField] private Text _levelInfo;
        [SerializeField] private Button _btnAccept;

        private void Awake()
        {
            _btnAccept.onClick.AddListener(() => { OnAcceptClick?.Invoke();});
        }

        public void SetLevelInfo(int chapter, int level)
        {
            _levelInfo.text = chapter + " - " + level;
        }
    }
}