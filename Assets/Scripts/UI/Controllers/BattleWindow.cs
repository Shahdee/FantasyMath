using System;
using System.Linq;
using Enemy;
using Level;
using UnityEngine;
using Zenject;

namespace UI
{
    public class BattleWindow : AbstractWindow, IDisposable
    {
        public override EWindowType WindowType => EWindowType.Battle;
        
        private readonly ILevelController _gameController;
        private readonly ITurnController _turnController;
        private readonly LazyInject<BattleWindowView> _view;
        
        private readonly IPlayerLifeFactory _playerLifeFactory;
        private readonly IPlayerModel _playerModel;
        private readonly ILevelModel _levelModel;
        private readonly IResultButtonFactory _resultButtonFactory;
        private readonly IEnemyModel _enemyModel;

        public BattleWindow(LazyInject<BattleWindowView> view,
                            IPlayerLifeFactory playerLifeFactory,
                            IPlayerModel playerModel,
                            ILevelModel levelModel,
                            IResultButtonFactory resultButtonFactory,
                            IEnemyModel enemyModel,
                            ILevelController gameController,
                            ITurnController turnController)
        {
            _gameController = gameController;
            _turnController = turnController;
            _view = view;
            _playerLifeFactory = playerLifeFactory;
            _playerModel = playerModel;
            _levelModel = levelModel;
            _resultButtonFactory = resultButtonFactory;
            _enemyModel = enemyModel;

            _gameController.OnLevelStart += LevelStart;
            _playerModel.OnLifeChange += PlayerLifeChange;
            _enemyModel.OnLifeChange += EnemyLifeChange;
            _levelModel.OnEquationPrepared += UpdateEquation;
        }

        protected override void OnAssignView() => SetView(_view.Value);
        
        protected override void OnAfterShow()
        {
            // ev + 

            _view.Value.OnResultSelect += ResultSelected;

            UpdateView();
        }

        protected override void OnAfterHide()
        {
            // ev -
            
            _view.Value.OnResultSelect -= ResultSelected;
        }

        private void LevelStart()
        {
            if (!_view.HasValue) return;

            UpdateLevelInfo();
            UpdateEnemyBar();
            UpdateEquation();
        }

        private void UpdateView()
        {
            if (!_view.HasValue) return;

            UpdatePlayerLives();
            UpdateEnemyBar();
            UpdateEquation();
        }

        private void UpdatePlayerLives()
        {
            var totalPlayerLives = _playerModel.TotalLives;
            var lives = _playerModel.Lives;

            var addLives = Mathf.Max(0,totalPlayerLives - _view.Value.Lives.Count);
            
            for (int i = 0; i < addLives; i++)
            {
                var life = _playerLifeFactory.CreateLife();
                _view.Value.AddLife(life);
            }
            
            _view.Value.SetLives(totalPlayerLives, lives);
        }

        private void UpdateLevelInfo() => _view.Value.SetLevelInfo(_levelModel.CurrentChapter + 1, _levelModel.CurrentLevelInChapter + 1);

        private void UpdateEnemyBar()
        {
            UpdateTimer();
            UpdateEnemyHealth();
        }

        private void UpdateTimer()
        {
            var showTimer = _levelModel.IsBossLevel();
            _view.Value.ShowTimer(showTimer);
        }

        private void UpdateEnemyHealth()
        {
            var total = _enemyModel.TotalLives;
            var lives = _enemyModel.Lives;
            
            _view.Value.SetEnemyLives(lives, total);
        }

        private void UpdateEquation()
        {
            _view.Value.SetEquation(_levelModel.FirstOperand, _levelModel.SecondOperand, _levelModel.OperationType);
            
            UpdateResultGroup();
        }
        
        private void UpdateResultGroup()
        {
            var results = _levelModel.Results;
            
            var addResults = Mathf.Max(0,results.Count() - _view.Value.ResultButtons.Count);
            
            for (int i = 0; i < addResults; i++)
            {
                var button = _resultButtonFactory.CreateButton();
                _view.Value.AddResultButton(button);
            }
            
            _view.Value.SetResults(results);
        }

        private void PlayerLifeChange(int lives)
        {
            UpdatePlayerLives();
        } 
        
        private void EnemyLifeChange(int lives)
        {
            UpdateEnemyHealth();
        }

        private void ResultSelected(int result)
        {
            _turnController.SendResults(result);
        }

        public void Dispose()
        {
            _gameController.OnLevelStart -= LevelStart;
        }
    }
}