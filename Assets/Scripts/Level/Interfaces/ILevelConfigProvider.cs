namespace Level
{
    public interface ILevelConfigProvider
    {
        LevelConfigData GetLevelConfigData();

        int GetPlayerLives();
        int GetEnemyLives();
        int GetPlayerDamage();
        int GetEnemyDamage();
    }
}