using System;
using System.Collections.Generic;

namespace Initialization
{
    public class InitializeMediator : Zenject.IInitializable, IDisposable
    {
        public event Action OnDone;
        
        private readonly List<IConfigInitialization> _configInitializables;

        private int _waiting;

        public InitializeMediator(List<IConfigInitialization> configInitializables)
        {
            _configInitializables = configInitializables;

            foreach (var configInitializable in _configInitializables)
                configInitializable.OnDone += ConfigInitializableDone;
        }
        
        public void Initialize()
        {
            _waiting = _configInitializables.Count;
            
            foreach (var configInitializable in _configInitializables)
                configInitializable.Initialize();
        }

        private void ConfigInitializableDone()
        {
            _waiting--;

            if (_waiting == 0)
                OnDone?.Invoke();
        }

        public void Dispose()
        {
            foreach (var configInitializable in _configInitializables)
                configInitializable.OnDone -= ConfigInitializableDone;
        }
    }
}