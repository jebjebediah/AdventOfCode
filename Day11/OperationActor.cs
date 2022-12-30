namespace Day11
{
    internal abstract class OperationActor
    {
        internal int operand;
        public int Modulus { get; set; }
        public OperationActor(int operand)
        {
            this.operand = operand;
        }

        public abstract int PerformOperation(int old);
    }
}