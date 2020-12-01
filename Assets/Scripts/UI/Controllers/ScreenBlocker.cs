namespace UI
{
    public class ScreenBlocker : IScreenBlocker
    {
        private readonly ScreenBlockerView _screenBlockerView;

        public ScreenBlocker(ScreenBlockerView screenBlockerView)
        {
            _screenBlockerView = screenBlockerView;
        }

        public void Show(bool show) => _screenBlockerView.Show(show);
    }
}