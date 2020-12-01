using System;

namespace Level
{
    public interface ILevelController
    {
        event Action OnGameStart;
        event Action OnGameRelaunch;
        event Action OnLevelStart;
        event Action OnChapterComplete;
        
        event Action OnGameOver;
        
        void StartGame();

        void RelaunchGame();
    }
}