using Zenject;

namespace Helpers
{
    public class CoroutineInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<CoroutineManager>().AsSingle();
        }
    }
}