namespace System
{
    public interface IPlayerModel
    {
        event Action OnDied;
        event Action<int> OnLifeChange;
        
        int Lives { get; }
        int TotalLives { get; }

        void SetLives(int lives);

        void AddLives(int lives);
    }
}