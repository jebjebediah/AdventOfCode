namespace Day11
{
    internal class SquareActor : OperationActor
    {
        public SquareActor(int operand) : base(operand)
        {
        }

        public override int PerformOperation(int old)
        {
            return (old * old) % Modulus;
        }
    }
}