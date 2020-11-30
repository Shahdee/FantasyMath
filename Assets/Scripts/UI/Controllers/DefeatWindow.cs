using Zenject;

namespace UI
{
    public class DefeatWindow : AbstractWindow
    {
        public override EWindowType WindowType => EWindowType.Defeat;
        
        private readonly LazyInject<DefeatWindowView> _view;
        
        public DefeatWindow(LazyInject<DefeatWindowView> view) 
        {
            _view = view;
        }
        
        protected override void OnAssignView() => SetView(_view.Value);
    }
}