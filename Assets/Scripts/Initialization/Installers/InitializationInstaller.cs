using Zenject;

namespace Initialization
{
    public class InitializationInstaller : MonoInstaller
    {

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<InitializeMediator>().AsSingle();
        }
    }
}