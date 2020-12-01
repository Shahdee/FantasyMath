using System;
using System.Collections.Generic;
using Operations.Enums;

namespace Level
{
    public interface ILevelModel
    {
        event Action OnEquationPrepared;
        event Action OnLevelTimeElapsed;
        
        int CurrentChapter { get; }
        int CurrentLevelInChapter { get; }
        int FirstOperand { get; }
        int SecondOperand { get; }
        EOperationType OperationType { get; }
        IEnumerable<int> Results { get; }
        float TotalTime { get; }
        float TimeLeft { get; }

        void SetChapterData(LevelConfigChapterData configChapterData);

        void SetLevelParams(int chapter, int level);
        
        bool IsBossLevel();

        int GetTotalLevels();

        void PrepareEquation();
    }
}