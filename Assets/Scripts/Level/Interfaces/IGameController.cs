using System;

namespace Level
{
    public interface IGameController
    {
        event Action OnGameStart;
        event Action OnLevelStart;
        event Action OnChapterComplete;
        
        event Action OnGameOver;
        
        void StartGame();
    }
}