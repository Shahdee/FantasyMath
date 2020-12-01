using System;
using System.Collections.Generic;
using System.Linq;
using Helpers;
using Operations;
using Operations.Enums;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Level
{
    public class LevelModel : ILevelModel, IUpdatable
    {
        public event Action OnEquationPrepared;
        public event Action OnLevelTimeElapsed;
        
        private readonly IOperationProvider _operationProvider;
        public int CurrentChapter => _currentChapter;
        public int CurrentLevelInChapter => _currentLevel;
        public int FirstOperand => _firstOperand;
        public int SecondOperand => _secondOperand;
        public EOperationType OperationType => _currentOperatiom;
        public IEnumerable<int> Results => _results;

        public float TotalTime => _totalTime;
        public float TimeLeft => _timeLeft;

        private readonly LevelData _levelData;
        
        private LevelConfigChapterData _configChapterData;
        
        private int _currentLevel = -1;
        private int _currentChapter = -1;
        private int _minRandomNumber = -1;
        private int _maxRandomNumber = -1;
        
        private int _firstOperand = -1;
        private int _secondOperand = -1;
        private int _operationResult = -1;
        private IEnumerable<int> _results;

        private bool _updateTimer;
        private float _totalTime;
        private float _timeLeft;
        
        private EOperationType _currentOperatiom = EOperationType.Summ;

        public LevelModel(IOperationProvider operationProvider)
        {
            _operationProvider = operationProvider;
        }

        public void SetChapterData(LevelConfigChapterData configChapterData)
        {
            _configChapterData = configChapterData;
        }

        public void SetLevelParams(int chapter, int level)
        {
            Debug.Log("SetLevelParams c/l: " + chapter + "/" + level);
            
            if (_currentChapter != chapter)
            {
                _currentChapter = chapter;
                UpdateOperationBase();
            }
            
            _currentLevel = level;
            UpdateOperation();

            if (IsBossLevel())
                SetTimer();
        }

        public bool IsBossLevel()
        {
            return _configChapterData.Levels == _currentLevel + 1;
        }

        public int GetTotalLevels() => _configChapterData.Levels;

        public void PrepareEquation()
        {
            UpdateOperation();
            OnEquationPrepared?.Invoke();
        }

        private void SetTimer()
        {
            _updateTimer = true;
            _totalTime = _configChapterData.BossTimeLimitSec;
            _timeLeft = _totalTime;
        }

        private void UpdateOperationBase()
        {
            _minRandomNumber = _configChapterData.MinNumber + _currentChapter * _configChapterData.NumberDelta; 
            _maxRandomNumber = _configChapterData.MaxNumber + _currentChapter * _configChapterData.NumberDelta;

            Debug.Log("_minRandomNumber " + _minRandomNumber + " / _maxRandomNumber " + _maxRandomNumber);
        }
        
        private void UpdateOperation()
        {
            _firstOperand = Random.Range(_minRandomNumber, _maxRandomNumber + 1);
            _secondOperand = Random.Range(_minRandomNumber, _maxRandomNumber + 1);
            _operationResult = _operationProvider.GetCorrectResult(_firstOperand, _secondOperand, _currentOperatiom);
            
            Debug.Log(  _firstOperand + " + " + _secondOperand + " = " + _operationResult);

            var results = _operationProvider.GetWrongResults(_firstOperand,
                                                        _secondOperand,
                                                                _configChapterData.WrongResultDelta,
                                                                _currentOperatiom,
                                                            _configChapterData.TotalNumberOfResults - 1);
            results.Add(_operationResult);
            _results = results.OrderBy(r => Random.value);
        }

        public void CustomUpdate(float deltaTime)
        {
            if (!_updateTimer)
                return;

            _timeLeft -= deltaTime;

            if (_timeLeft <= 0)
            {
                _updateTimer = false;
                OnLevelTimeElapsed?.Invoke();
            }
        }
    }
}