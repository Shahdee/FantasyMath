using System;
using DataLoader;
using Initialization;

namespace Level
{
    public class LevelConfigProvider : ILevelConfigProvider, IConfigInitialization
    {
        public event Action OnDone;
        
        private const string LevelConfigFileName = "LevelConfig.json";
        
        private readonly IDataLoader _dataLoader;

        private LevelConfigData _data;

        public LevelConfigProvider(IDataLoader dataLoader)
        {
            _dataLoader = dataLoader;
        }

        public void Initialize()
        {
            _dataLoader.LoadGameData<LevelConfigData>(LevelConfigFileName, (data) =>
            {
                _data = data;
                OnDone?.Invoke();
            });
        }

        public LevelConfigData GetLevelConfigData()
        {
            return _data;
        }

        public int GetPlayerLives() => _data.PlayerLives;
        public int GetPlayerDamage() => _data.PlayerDamage;
        public int GetEnemyLives() => _data.EnemyLives;
        public int GetEnemyDamage() => _data.EnemyDamage;
    }
}