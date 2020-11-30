using UnityEngine;

namespace UI
{
    public class PlayerLifeFactory : IPlayerLifeFactory
    {
        private readonly PlayerLifeView _lifePrefab;
        
        public PlayerLifeFactory(PlayerLifeView lifePrefab)
        {
            _lifePrefab = lifePrefab;
        }
        
        public IPlayerLifeView CreateLife()
        {
            return Object.Instantiate(_lifePrefab);
        }
    }
}