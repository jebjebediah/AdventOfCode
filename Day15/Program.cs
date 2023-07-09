using Common.Helpers;
using Day15;
using System.Text.RegularExpressions;

Cave cave = new Cave();

IEnumerable<string> lines = await PuzzleInputReader.GetPuzzleInputs("sample.txt");
Regex r = new Regex(@"(-?\d+)");

foreach (string line in lines)
{
    MatchCollection matches = r.Matches(line);

    Console.WriteLine($"{matches.ElementAt(0).Value},{matches.ElementAt(1).Value},{matches.ElementAt(2).Value},{matches.ElementAt(3).Value}");

    cave.AddSensor(int.Parse(matches.ElementAt(0).Value),
                   int.Parse(matches.ElementAt(1).Value),
                   int.Parse(matches.ElementAt(2).Value),
                   int.Parse(matches.ElementAt(3).Value));
}

Console.WriteLine(cave.FilledAtYRow(10));