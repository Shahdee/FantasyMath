using System;
using UnityEngine;

namespace Level
{
    [Serializable]
    public class LevelConfigChapterData
    {
        public int MinNumber => _minNumber;
        public int MaxNumber => _maxNumber;
        public int NumberDelta => _numberDelta;
        public int Levels => _levels;
        public int BossTimeLimitSec => _bossTimeLimitSec;
        
        [SerializeField] private int _minNumber;
        [SerializeField] private int _maxNumber;
        [SerializeField] private int _numberDelta;
        [SerializeField] private int _levels;
        [SerializeField] private int _bossTimeLimitSec;
    }
}