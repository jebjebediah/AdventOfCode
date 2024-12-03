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
        const int DO_VALUE = -1;
        const int DONT_VALUE = -2;

        IEnumerable<string> lines = await PuzzleInputReader.GetPuzzleInputs(ProblemNumber, 2, useSample);

        List<JumbledCommand> commands = new();

        int pageIndex = 0;
        foreach (string line in lines)
        {
            MatchCollection muls = Regex.Matches(line, @"(mul\(\d+,\d+\))");

            foreach (Match match in muls)
            {
                GroupCollection groups = match.Groups;
                string command = groups[1].Value;
                IEnumerable<int> numbers = command.Substring(4, command.Length - 5).Split(',').Select(n => int.Parse(n));
                commands.Add(new JumbledCommand
                {
                    Value = numbers.First() * numbers.Last(),
                    Page = pageIndex,
                    Index = groups[1].Index
                });
            }

            MatchCollection dos = Regex.Matches(line, @"(do\(\))");

            foreach (Match match in dos)
            {
                commands.Add(new JumbledCommand
                {
                    Value = DO_VALUE,
                    Page = pageIndex,
                    Index = match.Groups[1].Index
                });
            }

            MatchCollection donts = Regex.Matches(line, @"(don't\(\))");

            foreach (Match match in donts)
            {
                commands.Add(new JumbledCommand
                {
                    Value = DONT_VALUE,
                    Page = pageIndex,
                    Index = match.Groups[1].Index
                });
            }

            pageIndex++;
        }

        IOrderedEnumerable<JumbledCommand> orderedCommands = commands.OrderBy(c => c.Page).ThenBy(c => c.Index);

        int runningTotal = 0;

        bool doMode = true;
        foreach (JumbledCommand command in orderedCommands)
        {
            if (command.Value == DO_VALUE)
            {
                doMode = true;
            }
            else if (command.Value == DONT_VALUE)
            {
                doMode = false;
            }
            else if (doMode)
            {
                runningTotal += command.Value;
            }
        }

        return runningTotal.ToString();
    }
}

internal class JumbledCommand
{
    public int Value { get; set; }
    public int Page { get; set; }
    public int Index { get; set; }
}
