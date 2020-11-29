using Zenject;

namespace Level
{
    public class LevelInstaller : MonoInstaller
    {

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<GameController>().AsSingle();
            Container.BindInterfacesTo<TurnController>().AsSingle();
            Container.BindInterfacesTo<LevelModel>().AsSingle();
            Container.BindInterfacesTo<GameLauncher>().AsSingle();
            Container.BindInterfacesTo<LevelConfigProvider>().AsSingle();
        }
    }
}