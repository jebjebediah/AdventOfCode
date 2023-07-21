using Common.Helpers;
using Day15;
using System.Text.RegularExpressions;

Cave cave = new Cave();

IEnumerable<string> lines = await PuzzleInputReader.GetPuzzleInputs("input.txt");
Regex r = new Regex(@"(-?\d+)");

const int LevelToCheck = 2000000;

foreach (string line in lines)
{
    MatchCollection matches = r.Matches(line);

    cave.AddSensor(int.Parse(matches.ElementAt(0).Value),
                   int.Parse(matches.ElementAt(1).Value),
                   int.Parse(matches.ElementAt(2).Value),
                   int.Parse(matches.ElementAt(3).Value));
}

Console.WriteLine(cave.FilledAtYRow(LevelToCheck));