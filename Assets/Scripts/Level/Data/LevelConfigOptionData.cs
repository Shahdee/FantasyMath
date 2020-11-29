using System;
using UnityEngine;

namespace Level
{
    [Serializable]
    public class LevelConfigOptionData
    {
        public int TotalOptions => _totalOptions;
        public int OptionDelta => _optionDelta;
        
        [SerializeField] private int _totalOptions;
        [SerializeField] private int _optionDelta;
    }
}