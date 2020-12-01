using Level;
using Zenject;

namespace UI
{
    public class DefeatWindow : AbstractWindow
    {
        public override EWindowType WindowType => EWindowType.Defeat;
        
        private readonly LazyInject<DefeatWindowView> _view;
        private readonly ILevelController _levelController;
        private readonly ILevelModel _levelModel;

        public DefeatWindow(LazyInject<DefeatWindowView> view,
                            ILevelController levelController,
                            ILevelModel levelModel)
        {
            _view = view;
            _levelController = levelController;
            _levelModel = levelModel;
        }
        
        protected override void OnAssignView() => SetView(_view.Value);
        
        protected override void OnAfterShow()
        {
            _view.Value.OnAcceptClick += Accept;

            UpdateView();
        }

        private void UpdateView()
        {
            _view.Value.SetLevelInfo(_levelModel.CurrentChapter + 1, _levelModel.CurrentLevelInChapter + 1);
        }

        private void Accept()
        {
            _levelController.RelaunchGame();
        }

        protected override void OnAfterHide()
        {
            _view.Value.OnAcceptClick -= Accept;
        }
    }
}