using Zenject;

namespace Operations
{
    public class OperationInstaller : MonoInstaller
    {

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<OperationProvider>().AsSingle();
        }
    }
}