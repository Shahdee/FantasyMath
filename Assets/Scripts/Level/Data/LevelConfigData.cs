using System;
using UnityEngine;

namespace Level
{
    [Serializable]
    public class LevelConfigData
    {
        public LevelConfigChapterData  Chapter => _chapter;
        public int  PlayerLives => _playerLives;
        public int  EnemyLives => _enemyLives;
        public int  PlayerDamage => _playerDamage;
        public int  EnemyDamage => _enemyDamage;

        [SerializeField] private LevelConfigChapterData _chapter;
        [SerializeField] private int _playerLives;
        [SerializeField] private int _enemyLives;
        
        [SerializeField] private int _playerDamage;
        [SerializeField] private int _enemyDamage;
    }
}