using System;
using System.Collections.Generic;
using Initialization;
using UI.Enums;

namespace UI
{
    public class WindowController : IWindowController, IDisposable
    {
        private readonly IInitializeMediator _initializeMediator;
        private readonly List<IWindow> _windows;

        public WindowController(IInitializeMediator initializeMediator, List<IWindow> windows) 
        {
            _initializeMediator = initializeMediator;
            _windows = windows;

            _initializeMediator.OnDone += InitializeMediatorDone;
        }
        
        public void OpenWindow(EWindowType windowType)
        {
            // TODO
            // _windows
        }

        private void InitializeMediatorDone()
        {
            OpenWindow(EWindowType.Start);
        }

        public void Dispose()
        {
            _initializeMediator.OnDone -= InitializeMediatorDone;
        }
    }
}