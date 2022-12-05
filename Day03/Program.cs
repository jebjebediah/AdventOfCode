using Common.Helpers;
using Day03;

IEnumerable<string> lines = await PuzzleInputReader.GetPuzzleInputs();

int accumulator = 0;
int tripletAccumulator = 0;

List<string> tripletBags = new();

foreach (string line in lines)
{
    int value = BagHandler.ProcessBag(line);
    accumulator += value;

    tripletBags.Add(line);
    if (tripletBags.Count == 3)
    {
        tripletAccumulator += BagHandler.FindCommonItemPriority(tripletBags[0], tripletBags[1], tripletBags[2]);
        tripletBags.Clear();
    }
}

Console.WriteLine(accumulator); 
Console.WriteLine(tripletAccumulator);