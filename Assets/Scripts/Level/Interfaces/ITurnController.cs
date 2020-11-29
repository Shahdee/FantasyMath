using Operations.Enums;

namespace Level
{
    public interface ITurnController
    {
        void SendResults(int operand1, int operand2, EOperationType operationType, int result);
    }
}