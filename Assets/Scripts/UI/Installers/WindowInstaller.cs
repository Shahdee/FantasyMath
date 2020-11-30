using UnityEngine;
using Zenject;

namespace UI
{
    [CreateAssetMenu(fileName = "WindowInstaller",  menuName = "SO/Installers/WindowInstaller")]
    public class WindowInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private StartWindowView _startWindowView;
        [SerializeField] private BattleWindowView _battleWindowView;
        [SerializeField] private DefeatWindowView _defeatWindowView;
        [SerializeField] private PauseWindowView _pauseWindowView;
        [SerializeField] private SettingsWindowView _settingsWindowView;
        [SerializeField] private ChapterWindowView _chapterWindowView;
        
        [SerializeField] private PlayerLifeView _playerLife;
        [SerializeField] private ResultButtonView _resultButton;

        public override void InstallBindings()
        {
            Container.BindInstance(_playerLife);
            Container.BindInstance(_resultButton);
            
            Container.Bind<StartWindowView>().FromComponentInNewPrefab(_startWindowView).AsSingle();
            Container.Bind<BattleWindowView>().FromComponentInNewPrefab(_battleWindowView).AsSingle();
            Container.Bind<DefeatWindowView>().FromComponentInNewPrefab(_defeatWindowView).AsSingle();
            Container.Bind<PauseWindowView>().FromComponentInNewPrefab(_pauseWindowView).AsSingle();
            Container.Bind<SettingsWindowView>().FromComponentInNewPrefab(_settingsWindowView).AsSingle();
            Container.Bind<ChapterWindowView>().FromComponentInNewPrefab(_chapterWindowView).AsSingle();
            
            Container.BindInterfacesTo<WindowHandler>().AsSingle().NonLazy();
            
            Container.BindInterfacesTo<WindowController>().AsSingle();
            Container.BindInterfacesTo<StartWindow>().AsSingle();
            Container.BindInterfacesTo<BattleWindow>().AsSingle();
            Container.BindInterfacesTo<DefeatWindow>().AsSingle();
            
            Container.BindInterfacesTo<PlayerLifeFactory>().AsSingle();
            Container.BindInterfacesTo<ResultButtonFactory>().AsSingle();
        }
    }
}