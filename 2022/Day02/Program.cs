using Common.Helpers;
using Day02;

IEnumerable<string> lines = await PuzzleInputReader.GetPuzzleInputs();
List<string> lines1 = lines.ToList();

int accumulator = 0;
int cheatingAccumulator = 0;

foreach (var line in lines1)
{
    char moveA = line.ElementAt(0);
    char moveB = line.ElementAt(2);

    accumulator += RPSResolver.ResolveRound(moveA, moveB);
    cheatingAccumulator += RPSResolver.ResolveWithCheating(moveA, moveB);
}

Console.WriteLine($"First pass: {accumulator}");
Console.WriteLine($"Second pass: {cheatingAccumulator}");