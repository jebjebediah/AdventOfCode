using System.Text.RegularExpressions;
using Common;
using Common.Helpers;

namespace Problems.Day03;

public class Main : IAdventOfCodeProblem
{
    public string ProblemNumber => "03";

    public async Task<string> RunPart1(bool useSample)
    {
        IEnumerable<string> lines = await PuzzleInputReader.GetPuzzleInputs(ProblemNumber, 1, useSample);

        int runningTotal = 0;

        string pattern = @"(mul\(\d+,\d+\))";

        Regex mulFinder = new Regex(pattern);
        foreach (string line in lines)
        {
            MatchCollection m = Regex.Matches(line, pattern);

            foreach (Match match in m)
            {
                GroupCollection groups = match.Groups;
                string command = groups[1].Value;
                IEnumerable<int> numbers = command.Substring(4, command.Length - 5).Split(',').Select(n => int.Parse(n));
                runningTotal += numbers.First() * numbers.Last();
            }
        }

        return runningTotal.ToString();
    }

    public async Task<string> RunPart2(bool useSample)
    {
        throw new NotImplementedException();
    }
}
