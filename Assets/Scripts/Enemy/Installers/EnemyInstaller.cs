using UnityEngine;
using Zenject;

namespace Enemy
{
    [CreateAssetMenu(fileName = "EnemyInstaller",  menuName = "SO/Installers/EnemyInstaller")]
    public class EnemyInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private EnemyView _normalEnemy;
        [SerializeField] private EnemyView _bossEnemy;
        
        public override void InstallBindings()
        {
            // Container.Bind(_normalEnemy);
            // Container.BindInstance(_bossEnemy);
            
            Container.BindInterfacesTo<EnemyController>().AsSingle();
            Container.BindInterfacesTo<EnemyFactory>().AsSingle().WithArguments(_normalEnemy, _bossEnemy);
            Container.BindInterfacesTo<EnemyModel>().AsSingle();
        }
    }
}