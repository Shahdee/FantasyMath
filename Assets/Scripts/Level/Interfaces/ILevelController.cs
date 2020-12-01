using System;

namespace Level
{
    public interface ILevelController
    {
        event Action OnGameStart;
        event Action OnLevelStart;
        event Action OnChapterComplete;
        
        event Action OnGameOver;
        
        void StartGame();
    }
}