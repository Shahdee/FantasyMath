using System;
using System.Collections.Generic;
using Operations.Enums;
using UnityEngine;

namespace UI
{
    public class BattleWindowView : AbstractWindowView
    {
        public event Action<int> OnResultSelect;
        public List<IPlayerLifeView> Lives => _playerHp.Lives;
        public List<IResultButtonView> ResultButtons => _resultGroupView.Results;

        [SerializeField] private LevelInfoView _levelInfo;
        [SerializeField] private EnemyBarView _enemyBar;
        [SerializeField] private PlayerHpView _playerHp;
        [SerializeField] private EquationView _equationView;
        [SerializeField] private ResultGroupView _resultGroupView;

        private void Awake()
        {
            _resultGroupView.OnResultSelect += (result)=> {OnResultSelect?.Invoke(result);};
        }

        public void AddLife(IPlayerLifeView lifeView) => _playerHp.AddLife(lifeView);
        public void AddResultButton(IResultButtonView buttonView) => _resultGroupView.AddResultButton(buttonView);
        public void SetResults(IEnumerable<int> results) => _resultGroupView.SetResults(results);

        public void SetLives(int total, int current) => _playerHp.SetLives(total, current);
        
        public void SetEquation(int operand1, int operand2, EOperationType operationType)
        {
            _equationView.SetEquation(operand1, operand2, operationType);
        }

        public void SetEnemyLives(int current, int total) => _enemyBar.SetLifeHp(current, total);

        public void ShowTimer(bool show) => _enemyBar.ShowTimer(show);
        public void SetTime(float current, float total) => _enemyBar.SetTime(current, total);

        public void SetLevelInfo(int chapter, int level) => _levelInfo.SetLevelInfo(chapter, level);

        // settings button 

        // enemy hp 
        // timer 

        // Normal level 
        // chapter-level
        // enemy hp 
        // hp
        // operation
        // options 
        // my hp 

    }
}