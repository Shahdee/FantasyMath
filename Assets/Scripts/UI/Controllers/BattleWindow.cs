using System;
using Level;

namespace UI
{
    public class BattleWindow : AbstractWindow, IDisposable
    {
        private readonly IGameController _gameController;
        private readonly ITurnController _turnController;

        public BattleWindow(IGameController gameController,
                            ITurnController turnController)
        {
            _gameController = gameController;
            _turnController = turnController;

            _gameController.OnLevelStart += LevelStart;
        }

        private void LevelStart()
        {
            // reinit ui
        }

        private void OptionSelected()
        {
            // _turnController
            // send results 
        }

        public void Dispose()
        {
            _gameController.OnLevelStart -= LevelStart;
        }
    }
}