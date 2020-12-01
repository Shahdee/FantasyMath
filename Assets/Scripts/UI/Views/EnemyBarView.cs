using UnityEngine.UI;
using UnityEngine;

namespace UI
{
    public class EnemyBarView : MonoBehaviour
    {
        [SerializeField] private GameObject _timer;
        
        [SerializeField] private Text _timeLeft;

        [SerializeField] private Image _timerBar;
        
        [SerializeField] private Image _lifeBar;
        

        public void SetLifeHp(int value, int maxValue)
        {
            _lifeBar.fillAmount = (float)value / maxValue;
        } 
        
        public void SetTimeBar(int value, int maxValue)
        {
            _timerBar.fillAmount = (float)value / maxValue;
        }

        public void ShowTimer(bool show)
        {
            _timer.SetActive(show);
        }
    }
}