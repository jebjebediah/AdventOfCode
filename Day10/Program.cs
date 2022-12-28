using Common.Helpers;
using Day10;

internal class Program
{
    private static int cycleNumber = 1;
    private static int xReg = 1;
    private static string currentLine = string.Empty;
    private static List<int> signalStrengths = new();

    private static async Task Main(string[] args)
    {
        IEnumerable<string> lines = await PuzzleInputReader.GetPuzzleInputs();


        CRT crt = new CRT();

        foreach (string line in lines)
        {
            var words = line.Split(' ');

            string command = words.ElementAt(0);
            if (command == "noop")
            {
                crt.Noop();
            }
            else if (command == "addx")
            {
                int argument = int.Parse(words.ElementAt(1));

                crt.Addx(argument);
            }
        }

        int totalSum = crt.GetSignalStrengthAtCycle(20) +
            crt.GetSignalStrengthAtCycle(60) +
            crt.GetSignalStrengthAtCycle(100) +
            crt.GetSignalStrengthAtCycle(140) +
            crt.GetSignalStrengthAtCycle(180) +
            crt.GetSignalStrengthAtCycle(220);

        Console.WriteLine($"Sum strength: {totalSum}");
    }
}