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
    
        public void SetLinkedMonkeys(Monkey trueMonkey, Monkey falseMonkey)
        {
            TrueMonkey = trueMonkey;
            FalseMonkey = falseMonkey;
        }

        public void InspectAll()
        {
            foreach (Item item in Inventory)
            {
                InspectionCount++;
                item.WorryLevel = OperationActor.PerformOperation(item.WorryLevel);
                item.WorryLevel = ApplyRelief(item.WorryLevel);
                Monkey receiver = PassesTest(item.WorryLevel) ? TrueMonkey : FalseMonkey;
                ThrowItem(item, receiver);
            }

            Inventory.Clear();
        }

        private int ApplyRelief(int currentLevel)
        {
            return Convert.ToInt32(Math.Floor(currentLevel / 3.0));
        }

        private bool PassesTest(int currentLevel)
        {
            return currentLevel % TestArgument == 0;
        }

        private void ThrowItem(Item thrownItem, Monkey receiverMonkey)
        {
            receiverMonkey.Inventory.Add(thrownItem);
        }
    }
}