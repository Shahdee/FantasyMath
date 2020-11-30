using UnityEngine;

namespace UI
{
    public class ResultButtonFactory : IResultButtonFactory
    {
        private readonly ResultButtonView _resultPrefab;
        
        public ResultButtonFactory(ResultButtonView resultPrefab)
        {
            _resultPrefab = resultPrefab;
        }
        
        public IResultButtonView CreateButton()
        {
            return Object.Instantiate(_resultPrefab);
        }
    }
}
