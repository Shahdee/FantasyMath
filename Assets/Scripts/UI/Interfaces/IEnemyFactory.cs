namespace UI
{
    public interface IEnemyFactory
    {
        IEnemyView CreateEnemy(bool boss);
    }
}