using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ResultButtonView : MonoBehaviour, IResultButtonView
    {
        public event Action<string> OnBtnClick;
        
        [SerializeField] private Button _button;
        [SerializeField] private Text _btnText;

        private void Awake()
        {
            _button.onClick.AddListener(()=>OnBtnClick?.Invoke(_btnText.text));
        }

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
    }
}