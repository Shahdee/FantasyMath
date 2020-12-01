using Level;
using UnityEngine;

namespace UI
{
    public class WindowHandler : IWindowHandler
    {
        private readonly ILevelController _gameController;
        private readonly IWindowController _windowController;

        public WindowHandler(ILevelController gameController,
                            IWindowController windowController)
        {
            _gameController = gameController;
            _windowController = windowController;
            
            _gameController.OnGameStart += () => _windowController.OpenWindowAndCloseOthers(EWindowType.Battle);
            _gameController.OnGameRelaunch += () => _windowController.OpenWindowAndCloseOthers(EWindowType.Start);
            _gameController.OnGameOver += () => _windowController.OpenWindow(EWindowType.Defeat);
        }
    }
}