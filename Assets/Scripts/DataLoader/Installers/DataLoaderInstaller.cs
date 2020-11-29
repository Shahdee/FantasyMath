using Zenject;

namespace DataLoader
{
    public class DataLoaderInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<DataLoader>().AsSingle();
        }
    }
}