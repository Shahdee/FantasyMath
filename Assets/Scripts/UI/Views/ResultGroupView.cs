using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UI
{
    public class ResultGroupView : MonoBehaviour
    {
        public event Action<int, int> OnResultSelect;
        public List<IResultButtonView> Results => _resultButtons;

        private const float HighlightTime = 2f;
        
        private List<IResultButtonView> _resultButtons = new List<IResultButtonView>();
        
        public void AddResultButton(IResultButtonView button)
        {
            _resultButtons.Add(button);
            
            button.SetParent(transform);

            button.OnBtnClick += ResultButtonClick;
        }

        public void SetResults(IEnumerable<int> results)
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

        public int GetResultIndex(int result)
        {
            return _resultButtons.FindIndex(r => r.Result.Equals(result.ToString()));
        }

        public void HighlighResults(int correctIndex, int wrongIndex)
        {
            if (correctIndex < 0 || correctIndex >= _resultButtons.Count)
                return;
            
            if (wrongIndex < 0 || wrongIndex >= _resultButtons.Count)
                return;
            
            _resultButtons[correctIndex].SetHighlight(EResultHighlightType.Correct);
            _resultButtons[wrongIndex].SetHighlight(EResultHighlightType.Wrong);

            StartCoroutine(RestoreHightlight());
        }
        
        private IEnumerator RestoreHightlight()
        {
            yield return new WaitForSeconds(HighlightTime);
            ResetHighlight();
        }

        public void ResetHighlight()
        {
            for (int i = 0; i < _resultButtons.Count; i++)
                _resultButtons[i].ResetHighlight();
        }

        private void ResultButtonClick(IResultButtonView view, string text)
        {
            var resultIndex = _resultButtons.IndexOf(view);
            
            if (int.TryParse(text, out var result))
                OnResultSelect?.Invoke(resultIndex, result);
        }
    }
}