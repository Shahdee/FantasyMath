using UnityEngine;
using Zenject;

namespace Enemy
{
    [CreateAssetMenu(fileName = "EnemyInstaller",  menuName = "SO/Installers/EnemyInstaller")]
    public class EnemyInstaller : ScriptableObjectInstaller
    {
        
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<EnemyController>().AsSingle();
            
            Container.BindInterfacesTo<EnemyModel>().AsSingle();
        }
    }
}