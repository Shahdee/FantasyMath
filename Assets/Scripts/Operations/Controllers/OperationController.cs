using Operations.Enums;

namespace Operations
{
    public class OperationController : IOperationController
    {
        public bool CheckOperation(int operand1, int operand2, EOperationType operationType, int result)
        {
            switch (operationType)
            {
                case EOperationType.Summ:
                    return (operand1 + operand2) == result;
                
                case EOperationType.Substraction:
                    return (operand1 - operand2) == result;
                
                default:
                    return false;
            }
        }
    }
}