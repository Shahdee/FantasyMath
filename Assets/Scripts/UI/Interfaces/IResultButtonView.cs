using System;
using UnityEngine;

namespace UI
{
    public interface IResultButtonView
    {
        event Action<string> OnBtnClick;
        
        void SetResult(int result);

        void SetParent(Transform parent);

        void Show(bool show);
    }
}