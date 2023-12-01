using Common.Helpers;

IEnumerable<string> lines = await PuzzleInputReader.GetPuzzleInputs();

List<int> elfTotals = new();

int calorieAccumulator = 0;
foreach (string line in lines)
{
    if (line == "")
    {
        elfTotals.Add(calorieAccumulator);
        calorieAccumulator = 0;
    }
    else
    {
        calorieAccumulator += int.Parse(line);
    }
}

Console.WriteLine($"Max: {elfTotals.Max()}");
Console.WriteLine($"Sum of 3 highest: {elfTotals.OrderByDescending(c => c).Take(3).Sum()}");