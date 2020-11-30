using System;
using Level;
using UnityEngine;
using Zenject;

namespace UI
{
    public class StartWindow : AbstractWindow, IDisposable
    {
        public override EWindowType WindowType => EWindowType.Start;
        
        private readonly IGameLauncher _gameLauncher;
        
        private readonly LazyInject<StartWindowView> _view;

        public StartWindow(LazyInject<StartWindowView> view, 
                            IGameLauncher gameLauncher)
        {
            _gameLauncher = gameLauncher;
            _view = view;
        }

        protected override void OnAssignView() => SetView(_view.Value);

        protected override void OnAfterShow()
        {
            // ev + 

            _view.Value.OnPlay += StartGame;
        }

        protected override void OnAfterHide()
        {
            // ev -
            
            _view.Value.OnPlay -= StartGame;
        }

        private void StartGame()
        {
            Debug.LogError("start game ");
            
            _gameLauncher.LaunchGame();
        }

        public void Dispose()
        {
            if (!_view.Value) return;
            
            _view.Value.OnPlay -= StartGame;
        }
    }
}