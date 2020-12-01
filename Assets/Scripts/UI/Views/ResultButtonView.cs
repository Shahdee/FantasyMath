using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ResultButtonView : MonoBehaviour, IResultButtonView
    {
        public event Action<IResultButtonView, string> OnBtnClick;
        
        [SerializeField] private Button _button;
        [SerializeField] private Text _btnText;
        [SerializeField] private Image _bg;
        
        [SerializeField] private Color _red;
        [SerializeField] private Color _green;
        [SerializeField] private Color _white;

        private void Awake()
        {
            _button.onClick.AddListener(()=>OnBtnClick?.Invoke(this, _btnText.text));
        }

        public string Result => _btnText.text;

        public void SetResult(int result)
        {
            _btnText.text = result.ToString();
        }
        
        public void SetParent(Transform parent)
        {
            transform.SetParent(parent);
        }

        public void Show(bool show)
        {
            gameObject.SetActive(show);
        }

        public void SetHighlight(EResultHighlightType highlightType)
        {
            switch (highlightType)
            {
                case EResultHighlightType.Neutral:
                    _bg.color = _white;
                    break;
                
                case EResultHighlightType.Correct:
                    _bg.color = _green;
                    break;
                
                case EResultHighlightType.Wrong:
                    _bg.color = _red;
                    break;
            }
        }

        public void ResetHighlight() => _bg.color = _white;
        public void SetInteraction(bool interact) => _button.interactable = interact;
    }
}