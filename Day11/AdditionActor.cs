namespace Day11
{
    internal class AdditonActor : OperationActor
    {
        public AdditonActor(int operand) : base(operand)
        {
        }

        public override int PerformOperation(int old)
        {
            return (old + operand) % Modulus;
        }
    }
}