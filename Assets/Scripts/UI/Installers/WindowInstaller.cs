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

        public override void InstallBindings()
        {
            Container.Bind<StartWindowView>().FromComponentInNewPrefab(_startWindowView).AsSingle();
            Container.Bind<BattleWindowView>().FromComponentInNewPrefab(_battleWindowView).AsSingle();
            Container.Bind<DefeatWindowView>().FromComponentInNewPrefab(_defeatWindowView).AsSingle();
            Container.Bind<PauseWindowView>().FromComponentInNewPrefab(_pauseWindowView).AsSingle();
            Container.Bind<SettingsWindowView>().FromComponentInNewPrefab(_settingsWindowView).AsSingle();
            Container.Bind<ChapterWindowView>().FromComponentInNewPrefab(_chapterWindowView).AsSingle();
            
            Container.BindInterfacesTo<WindowController>().AsSingle();
            Container.BindInterfacesTo<WindowHandler>().AsSingle().NonLazy();
            Container.BindInterfacesTo<StartWindow>().AsSingle();
            Container.BindInterfacesTo<BattleWindow>().AsSingle();
            Container.BindInterfacesTo<DefeatWindow>().AsSingle();
        }
    }
}