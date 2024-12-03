using Common;
using Common.Helpers;

namespace Problems.Day02;

public class Main : IAdventOfCodeProblem
{
    public string ProblemNumber => "02";

    public async Task<string> RunPart1(bool useSample)
    {
        IEnumerable<string> lines = await PuzzleInputReader.GetPuzzleInputs(ProblemNumber, 1, useSample);

        int safeReportCount = 0;

        foreach (string line in lines)
        {
            IEnumerable<string> splitLine = line.Split(' ');
            IEnumerable<int> report = splitLine.Select(s => int.Parse(s));

            if (CheckMonotonicity(report) && CheckGapping(report)) { safeReportCount++; }
        }

        return safeReportCount.ToString();
    }

    private bool CheckMonotonicity(IEnumerable<int> levels)
    {
        var orderedForward = levels.OrderBy(x => x).ToList();
        var orderedBackward = levels.OrderByDescending(x => x).ToList();

        if (Enumerable.SequenceEqual(levels, orderedForward) || Enumerable.SequenceEqual(levels, orderedBackward))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool CheckGapping(IEnumerable<int> levels)
    {
        for (int i = 0; i < levels.Count() - 1; i++)
        {
            int current = levels.ElementAt(i);
            int next = levels.ElementAt(i + 1);
            int distance = DistanceBetween(current, next);

            if (!(distance >= 1 && distance <= 3))
            {
                return false;
            }
        }
        
        return true;
    }

    private int DistanceBetween(int a, int b)
    {
        return int.Max(a, b) - int.Min(a, b);
    }

    public Task<string> RunPart2(bool useSample)
    {
        throw new NotImplementedException();
    }
}
