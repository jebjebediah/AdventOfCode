using Common.Helpers;
using Day05;
using System.Text.RegularExpressions;

internal class Program
{
    private static async Task Main(string[] args)
    {
        const int maxStackHeight = 8;
        const int stacksCount = 9;

        IEnumerable<string> lines = await PuzzleInputReader.GetPuzzleInputs();

        CargoHold hold = new CargoHold(stacksCount);

        for (int i = maxStackHeight - 1; i >= 0; i--)
        {
            string row = lines.ElementAt(i);

            int k = 0;
            for (int j = 1; j < row.Length; j += 4)
            {
                char elementHere = row.ElementAt(j);

                if (char.IsLetter(elementHere))
                {
                    hold.AddToStack(k, elementHere);
                }
                k++;
            }
        }

        IEnumerable<string> instructions = lines.Skip(10);

        Regex instructionRegex = new Regex(@"move (\d+) from (\d+) to (\d+)");

        foreach (string instruction in instructions)
        {
            Match match = instructionRegex.Match(instruction);

            if (match.Success)
            {
                int count = int.Parse(match.Groups[1].Value);
                int fromIndex = int.Parse(match.Groups[2].Value);
                int toIndex = int.Parse(match.Groups[3].Value);

                hold.DoMove(fromIndex - 1, toIndex - 1, count);
            }
        }

        Console.WriteLine(hold.GetTop());
    }
}