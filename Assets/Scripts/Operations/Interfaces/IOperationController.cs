using Operations.Enums;

namespace Operations
{
    public interface IOperationController
    {
        bool CheckOperation(int operand1, int operand2, EOperationType operationType, int result);
    }
}