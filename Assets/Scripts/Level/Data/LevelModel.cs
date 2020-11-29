namespace Level
{
    public class LevelModel : ILevelModel
    {
        public int CurrentChapter
        {
            get { return _currentChapter; }
            set { _currentChapter = value; }
        }
        
        public int CurrentLevelInChapter
        {
            get { return _currentLevel; }
            set { _currentLevel = value; }
        }
        
        private readonly LevelData _levelData;
        
        private LevelConfigChapterData _configChapterData;
        
        private int _currentLevel;
        private int _currentChapter;

        public LevelModel()
        {
            
        }

        public void SetChapterData(LevelConfigChapterData configChapterData)
        {
            _configChapterData = configChapterData;
            
        }

        public void SetLevelParams(int chapter, int level)
        {
            _currentChapter = chapter;
            _currentLevel = level;
        }

        public bool IsBossLevel()
        {
            return _configChapterData.Levels == _currentLevel + 1;
        }

        public int GetTotalLevels() => _configChapterData.Levels;
    }
}