using Level;
using UnityEngine;

namespace UI
{
    public class WindowHandler : IWindowHandler
    {
        private readonly IGameController _gameController;
        private readonly IWindowController _windowController;

        public WindowHandler(IGameController gameController,
                            IWindowController windowController)
        {
            _gameController = gameController;
            _windowController = windowController;
            
            Debug.LogError("window handler const");

            _gameController.OnGameStart += () => _windowController.OpenWindowAndCloseOthers(EWindowType.Battle);
            _gameController.OnGameOver += () => _windowController.OpenWindow(EWindowType.Defeat);
        }
    }
}