namespace System
{
    public interface IPlayerModel
    {
        event Action OnPlayerDied;
        
        int Lives { get; }

        void SetLives(int lives);

        void AddLives(int lives);
    }
}