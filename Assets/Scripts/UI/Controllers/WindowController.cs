using System;
using System.Collections.Generic;
using System.Linq;
using Initialization;
using UnityEngine;

namespace UI
{
    public class WindowController : IWindowController, IDisposable
    {
        private readonly IInitializeMediator _initializeMediator;
        private readonly List<IWindow> _windows;

        private Transform _windowParent;
        private Stack<IWindow> _windowStack;

        public WindowController(IInitializeMediator initializeMediator, List<IWindow> windows) 
        {
            _initializeMediator = initializeMediator;
            _windows = windows;
            
            _windowStack = new Stack<IWindow>();
            _initializeMediator.OnDone += InitializeMediatorDone;
        }

        public void OpenWindowAndCloseOthers(EWindowType windowType)
        {
            // Debug.LogError("ow and close others " + windowType);
            
            while (_windowStack.Count > 0)
            {
                var window = _windowStack.Peek();
                window.Hide();
            }
            OpenWindow(windowType);
        }
        
        public void OpenWindow(EWindowType windowType)
        {
            // Debug.LogError("ow " + windowType);
            
            var window = _windows.FirstOrDefault(w => w.WindowType == windowType);
            if (window != null)
            {
                _windowStack.Push(window);
                var order = _windowStack.Count;
                window.SetOrder(order);
                window.Show();
            }
        }
        
        public void HideWindow(EWindowType windowType)
        {
            var window = _windows.FirstOrDefault(w => w.WindowType == windowType);
            if (window != null)
            {
                window.Hide();
            }
        }

        private void WindowClosed(EWindowType windowType)
        {
            var window = _windowStack.Peek();
            if (window.WindowType == windowType)
            {
                _windowStack.Pop();
            }
            else
                Debug.LogError("closed window is not on top " + windowType);
        }

        private void InitializeMediatorDone()
        {
            _windowParent = new GameObject().transform;
            _windowParent.name = "windowParent";

            foreach (var window in _windows)
            {
                window.SetParent(_windowParent);
                window.OnClose += WindowClosed;
            }

            OpenWindow(EWindowType.Start);
        }

        public void Dispose()
        {
            _initializeMediator.OnDone -= InitializeMediatorDone;
            
            foreach (var window in _windows)
                window.OnClose -= WindowClosed;
        }
    }
}