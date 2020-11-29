using UnityEngine;
using Zenject;

namespace UI
{
    [CreateAssetMenu(fileName = "WindowInstaller",  menuName = "SO/Installers/WindowInstaller")]
    public class WindowInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private StartWindowView _startWindowView;

        public override void InstallBindings()
        {
            Container.BindInstance(_startWindowView);
            
            Container.BindInterfacesTo<WindowController>().AsSingle();
            Container.BindInterfacesTo<WindowHandler>().AsSingle();
            Container.BindInterfacesTo<StartWindow>().AsSingle();
            Container.BindInterfacesTo<BattleWindow>().AsSingle();
            Container.BindInterfacesTo<DefeatWindow>().AsSingle();
        }
    }
}