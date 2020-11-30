using System;
using UnityEngine;

namespace Level
{
    [Serializable]
    public class LevelConfigChapterData
    {
        public int MinNumber => _minRandomNumber;
        public int MaxNumber => _maxRandomNumber;
        public int NumberDelta => _randomNumberDelta;
        public int WrongResultDelta => _wrongResultDelta;
        public int TotalNumberOfResults => _totalNumberOfResults;
        public int Levels => _levels;
        public int BossTimeLimitSec => _bossTimeLimitSec;
        
        [SerializeField] private int _minRandomNumber;
        [SerializeField] private int _maxRandomNumber;
        [SerializeField] private int _randomNumberDelta;
        [SerializeField] private int _wrongResultDelta;
        [SerializeField] private int _totalNumberOfResults;
        [SerializeField] private int _levels;
        [SerializeField] private int _bossTimeLimitSec;
    }
}