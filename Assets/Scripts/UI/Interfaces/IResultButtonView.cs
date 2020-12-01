using System;
using UnityEngine;

namespace UI
{
    public interface IResultButtonView
    {
        event Action<IResultButtonView, string> OnBtnClick;
        
        string Result { get; }
        
        void SetResult(int result);

        void SetParent(Transform parent);

        void Show(bool show);
        void SetHighlight(EResultHighlightType highlightType);
        void ResetHighlight();
    }
}