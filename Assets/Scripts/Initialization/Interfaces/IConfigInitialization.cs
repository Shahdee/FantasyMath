using System;

namespace Initialization
{
    public interface IConfigInitialization
    {
        event Action OnDone;
        void Initialize();
    }
}