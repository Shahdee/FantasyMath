using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class LevelInfoView : MonoBehaviour
    {
        [SerializeField] private Text _levelInfo;

        public void SetLevelInfo(int chapter, int level)
        {
            _levelInfo.text = chapter + " - " + level;
        }
    }
}