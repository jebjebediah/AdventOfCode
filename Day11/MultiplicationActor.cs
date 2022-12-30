namespace Day11
{
    internal class MultiplicationActor : OperationActor
    {
        public MultiplicationActor(int operand) : base(operand)
        {
        }

        public override int PerformOperation(int old)
        {
            return (old * operand) % Modulus;
        }
    }
}