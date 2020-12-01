using System.Collections.Generic;
using Operations.Enums;

namespace Operations
{
    public class OperationProvider : IOperationProvider
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

        public int GetCorrectResult(int operand1, int operand2, EOperationType operationType)
        {
            switch (operationType)
            {
                case EOperationType.Summ:
                    return (operand1 + operand2);
                
                case EOperationType.Substraction:
                    return (operand1 - operand2);
                
                default:
                    return (operand1 + operand2);
            }
        }

        public List<int> GetWrongResults(int operand1, int operand2, int wrongResultDelta, EOperationType operationType, int numberOfResults)
        {
            var results = new List<int>();

            if (numberOfResults <= 0)
                return results;
            
            var correctResult = GetCorrectResult(operand1, operand2, operationType);
            var count = 0;

            while (count < numberOfResults)
            {
                var randomResult = UnityEngine.Random.Range(correctResult - wrongResultDelta, correctResult + wrongResultDelta + 1);
                    
                if (randomResult == correctResult || results.Contains(randomResult))
                    continue;
                
                results.Add(randomResult);
                count++;
            }
            return results;
        }
    }
}