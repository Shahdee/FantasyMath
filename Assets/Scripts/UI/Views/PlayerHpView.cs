using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class PlayerHpView : MonoBehaviour
    {
        public List<IPlayerLifeView> Lives => _lives;
        
        private List<IPlayerLifeView> _lives = new List<IPlayerLifeView>();

        public void AddLife(IPlayerLifeView life)
        {
            _lives.Add(life);
            
            life.SetParent(transform);
        }

        public void SetLives(int total, int current)
        {
            for (int i=0; i<_lives.Count; i++)
            {
                _lives[i].Show(i < current);
            }
        }
    }
}