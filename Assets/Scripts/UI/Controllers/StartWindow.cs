using Level;

namespace UI
{
    public class StartWindow : AbstractWindow
    {
        private readonly IGameLauncher _gameLauncher;

        public StartWindow(IGameLauncher gameLauncher)
        {
            _gameLauncher = gameLauncher;
        }


        private void StartGame()
        {
            _gameLauncher.LaunchGame();
        }
    }
}