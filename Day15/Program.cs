using Common.Helpers;
using Day15;
using System.Text.RegularExpressions;

Cave cave = new Cave();

IEnumerable<string> lines = await PuzzleInputReader.GetPuzzleInputs("input.txt");
Regex r = new Regex(@"(-?\d+)");

foreach (string line in lines)
{
    MatchCollection matches = r.Matches(line);

    cave.AddSensor(int.Parse(matches.ElementAt(0).Value),
                   int.Parse(matches.ElementAt(1).Value),
                   int.Parse(matches.ElementAt(2).Value),
                   int.Parse(matches.ElementAt(3).Value));
}

CavePosition pos = cave.FindBeaconSpot(0, 4000000);
Console.WriteLine($"X:{pos.X}, Y:{pos.Y}");

ulong finalValue = ((ulong)pos.X * 4000000) + (ulong)pos.Y;
Console.WriteLine($"Tuning Frequency: {finalValue}");