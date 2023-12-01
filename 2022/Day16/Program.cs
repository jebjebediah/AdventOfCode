using Common.Helpers;
using System.Text.RegularExpressions;

IEnumerable<string> lines = await PuzzleInputReader.GetPuzzleInputs("sample.txt");
Regex r = new Regex(@"Valve ([A-Z][A-Z]) has flow rate=(\d+); tunnels? leads? to valves? ((?:[A-Z][A-Z](?:, )?)+)");

foreach (string line in lines)
{
    MatchCollection matches = r.Matches(line);

    var match = matches.ElementAt(0);
    var groups = match.Groups;

    string valveName = groups[1].Value;
    int rate = int.Parse(groups[2].Value);

    string connectionNames = groups[3].Value;

    string[] splitNames = connectionNames.Replace(" ", "").Split(",");
}
