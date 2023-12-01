using System.Text.RegularExpressions;
using Common.Helpers;
using Day14;

internal class Program
{
    private static async Task Main(string[] args)
    {
        IEnumerable<string> lines = await PuzzleInputReader.GetPuzzleInputs();

        Cave cave = new Cave((500, 0));

        Regex r = new Regex(@"(\d+),(\d+)");
        foreach (string line in lines)
        {
            MatchCollection matches = r.Matches(line);

            (int x, int depth) startingCoordinate = MatchToCoordinate(matches.First());
            foreach (Match match in matches.Skip(1))
            {
                (int x, int depth) endingCoordinate = MatchToCoordinate(match);
                cave.CreateLine(startingCoordinate, endingCoordinate);
                startingCoordinate = endingCoordinate;
            }
        }

        int settledSand = cave.EverythingFalls();
        Console.WriteLine(settledSand);
    }

    private static (int x, int depth) MatchToCoordinate(Match match)
    {
        return (int.Parse(match.Groups[1].Value), int.Parse(match.Groups[2].Value));
    }

}