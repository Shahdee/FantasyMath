using UnityEngine.Events;

namespace DataLoader
{
    public interface IDataLoader
    {
        void LoadGameData<T>(string fileName, UnityAction<T> onLoaded);
    }
}