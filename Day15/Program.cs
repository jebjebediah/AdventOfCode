using Common.Helpers;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, 15!");

Cave cave = new Cave();

IEnumerable<string> lines = await PuzzleInputReader.GetPuzzleInputs("sample.txt");
Regex r = new Regex(@"(\d+)");

foreach (string line in lines)
{
    MatchCollection matches = r.Matches(line);

    cave.AddSensor(int.Parse(matches[0]),
                   int.Parse(matches[1]),
                   int.Parse(matches[2]),
                   int.Parse(matches[3]));
}