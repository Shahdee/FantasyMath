namespace Level
{
    public interface ILevelModel
    {
        int CurrentChapter { get; set; }
        int CurrentLevelInChapter { get; set; }

        void SetChapterData(LevelConfigChapterData configChapterData);

        void SetLevelParams(int chapter, int level);
        
        bool IsBossLevel();

        int GetTotalLevels();
    }
}