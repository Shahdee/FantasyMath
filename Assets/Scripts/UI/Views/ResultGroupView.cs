using System;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class ResultGroupView : MonoBehaviour
    {
        public event Action<int> OnResultSelect;
        public List<IResultButtonView> Results => _resultButtons;
        
        private List<IResultButtonView> _resultButtons = new List<IResultButtonView>();
        
        public void AddResultButton(IResultButtonView button)
        {
            _resultButtons.Add(button);
            
            button.SetParent(transform);

            button.OnBtnClick += ResultButtonClick;
        }

        public void SetResults(HashSet<int> results)
        {
            var count = 0;
            foreach (var result in results)
            {
                if (count < _resultButtons.Count)
                {
                    _resultButtons[count].Show(true);
                    _resultButtons[count].SetResult(result);
                    count++;
                }
                else
                    break;
            }
            
            for (int i = count; i < _resultButtons.Count; i++)
            {
                _resultButtons[i].Show(false);
            }
        }

        private void ResultButtonClick(string text)
        {
            if (int.TryParse(text, out var result))
                OnResultSelect?.Invoke(result);
        }
    }
}