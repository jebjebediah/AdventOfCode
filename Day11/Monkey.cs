using System.Numerics;

namespace Day11
{
    internal class Monkey
    {
        public List<Item> Inventory { get; set; }
        public int TestArgument { get; set; }
        public Monkey? TrueMonkey { get; set; }
        public Monkey? FalseMonkey { get; set; }
        public OperationActor OperationActor { get; set; }
        public int TrueMonkeyIndex { get; set; }
        public int FalseMonkeyIndex { get; set; }
        public int InspectionCount { get; set; }
        public int Modulus { get; set; }

        public void SetLinkedMonkeys(Monkey trueMonkey, Monkey falseMonkey)
        {
            TrueMonkey = trueMonkey;
            FalseMonkey = falseMonkey;
        }

        public void InspectAll(bool doApplyRelief)
        {
            foreach (Item item in Inventory)
            {
                try
                {
                    InspectionCount++;
                    item.WorryLevel = OperationActor.PerformOperation(item.WorryLevel);

                    if (doApplyRelief)
                    {
                        item.WorryLevel = ApplyRelief(item.WorryLevel);
                    }

                    Monkey receiver = PassesTest(item.WorryLevel) ? TrueMonkey : FalseMonkey;
                    ThrowItem(item, receiver);

                }
                catch (OverflowException)
                {
                    throw new Exception();
                }
            }

            Inventory.Clear();
        }

        private int ApplyRelief(int currentLevel)
        {
            return currentLevel / 3;
        }

        private bool PassesTest(BigInteger currentLevel)
        {
            return currentLevel % TestArgument == 0;
        }

        private void ThrowItem(Item thrownItem, Monkey receiverMonkey)
        {
            receiverMonkey.Inventory.Add(thrownItem);
        }
    }
}