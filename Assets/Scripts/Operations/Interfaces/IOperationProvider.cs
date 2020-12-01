using System.Collections.Generic;
using Operations.Enums;

namespace Operations
{
    public interface IOperationProvider
    {
        bool CheckOperation(int operand1, int operand2, EOperationType operationType, int result);

        int GetCorrectResult(int operand1, int operand2, EOperationType operationType);
        
        List<int> GetWrongResults(int operand1, int operand2, int wrongResultDelta, EOperationType operationType, int numberOfResults);
    }
}