using Common.Helpers;
using Day11;

internal class Program
{
    private static async Task Main(string[] args)
    {
        IEnumerable<string> lines = await PuzzleInputReader.GetPuzzleInputs();
        IEnumerator<string> linesEnumerator = lines.GetEnumerator();

        List<Monkey> monkeys = new();

        while (linesEnumerator.MoveNext())
        {
            linesEnumerator.MoveNext(); //Skip the Monkey: header, move to Starting items

            string itemsList = linesEnumerator.Current;
            List<Item> items = InitializeInventory(itemsList).ToList();

            linesEnumerator.MoveNext(); //Move to Operation

            string operationString = linesEnumerator.Current;
            OperationActor operationActor = GetOperationActor(operationString);

            linesEnumerator.MoveNext(); //Move to Test

            string testString = linesEnumerator.Current;
            int testOperand = GetTestArgument(testString);

            linesEnumerator.MoveNext(); //Move to True action

            string trueConString = linesEnumerator.Current;
            int trueMonkeyIndex = GetLinkedMonkeyIndex(trueConString);

            linesEnumerator.MoveNext(); //Move to False action

            string falseConString = linesEnumerator.Current;
            int falseMonkeyIndex = GetLinkedMonkeyIndex(falseConString);

            monkeys.Add(new Monkey
            {
                Inventory = items,
                OperationActor = operationActor,
                TestArgument = testOperand,
                TrueMonkeyIndex = trueMonkeyIndex,
                FalseMonkeyIndex = falseMonkeyIndex
            });

            linesEnumerator.MoveNext();
        }

        foreach (Monkey monkey in monkeys) //Hook up true and false monkeys
        {
            Monkey trueMonkey = monkeys.ElementAt(monkey.TrueMonkeyIndex);
            Monkey falseMonkey = monkeys.ElementAt(monkey.FalseMonkeyIndex);

            monkey.SetLinkedMonkeys(trueMonkey, falseMonkey);
        }

        for (int i = 0; i < 20; i++)
        {
            foreach (Monkey monkey in monkeys)
            {
                monkey.InspectAll();
            }
        }

        IEnumerable<Monkey> businestMonkeys = monkeys.OrderByDescending(m => m.InspectionCount).Take(2);
        int totalMonkeyBusiness = businestMonkeys.ElementAt(0).InspectionCount * businestMonkeys.ElementAt(1).InspectionCount;

        Console.WriteLine($"Monkey business: {totalMonkeyBusiness}");
    }

    public static IEnumerable<Item> InitializeInventory(string startingItemString)
    {
        string[] words = startingItemString.Split(' ');

        IEnumerable<string> numberStrings = startingItemString.Substring(18).Split(",");

        List<Item> inventory = new();
        foreach (string number in numberStrings)
        {
            string numberWithoutPunctuation = number.Trim();
            int worryLevel = int.Parse(numberWithoutPunctuation);
            Item newItem = new Item(worryLevel);
            inventory.Add(newItem);
        }

        return inventory;
    }

    public static OperationActor GetOperationActor(string operationString)
    {
        List<string> words = operationString.Split(' ').ToList();

        string operation = words.ElementAt(6);
        string operand = words.ElementAt(7);

        if (operand == "old")
        {
            return new SquareActor(0);
        }
        else if (operation == "+")
        {
            return new AdditonActor(int.Parse(operand));
        }
        else if (operation == "*")
        {
            return new MultiplicationActor(int.Parse(operand));
        }
        else 
        {
            throw new ArgumentException();
        }
    }

    public static int GetTestArgument(string testString)
    {
        List<string> words = testString.Split(' ').ToList();

        int divNum = int.Parse(words.ElementAt(5));

        return divNum;
    }

    public static int GetLinkedMonkeyIndex(string monkeyLinkString)
    {
        string[] words = monkeyLinkString.Split(' ');

        int monkeyIndex = int.Parse(words.ElementAt(9));

        return monkeyIndex;
    }
}