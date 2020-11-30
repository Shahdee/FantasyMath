using Operations.Enums;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class EquationView : MonoBehaviour
    {
        [SerializeField] private Text _operand1Text;
        [SerializeField] private Text _operand2Text;
        [SerializeField] private Text _operationText;
        
        public void SetEquation(int operand1, int operand2, EOperationType operationType)
        {
            _operand1Text.text = operand1.ToString();
            _operand2Text.text = operand2.ToString();
            
            switch (operationType)
            {
                case EOperationType.Summ:
                    _operationText.text = "+";
                    break; 
                
                case EOperationType.Substraction:
                    _operationText.text = "-";
                    break;
            }
        }
    }
}