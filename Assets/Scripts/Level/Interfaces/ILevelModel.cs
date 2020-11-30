using System.Collections.Generic;
using Operations.Enums;

namespace Level
{
    public interface ILevelModel
    {
        int CurrentChapter { get; }
        int CurrentLevelInChapter { get; }
        int FirstOperand { get; }
        int SecondOperand { get; }
        EOperationType OperationType { get; }
        HashSet<int> Results { get; }

        void SetChapterData(LevelConfigChapterData configChapterData);

        void SetLevelParams(int chapter, int level);
        
        bool IsBossLevel();

        int GetTotalLevels();
    }
}