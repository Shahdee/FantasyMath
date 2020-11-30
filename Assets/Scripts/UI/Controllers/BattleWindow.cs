using System;
using Level;
using Zenject;

namespace UI
{
    public class BattleWindow : AbstractWindow, IDisposable
    {
        public override EWindowType WindowType => EWindowType.Battle;
        
        private readonly IGameController _gameController;
        private readonly ITurnController _turnController;
        private readonly LazyInject<BattleWindowView> _view;

        public BattleWindow(LazyInject<BattleWindowView> view,
                            IGameController gameController,
                            ITurnController turnController)
        {
            _gameController = gameController;
            _turnController = turnController;
            _view = view;

            _gameController.OnLevelStart += LevelStart;
        }

        protected override void OnAssignView() => SetView(_view.Value);

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