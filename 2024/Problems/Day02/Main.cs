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

    public async Task<string> RunPart2(bool useSample)
    {
        IEnumerable<string> lines = await PuzzleInputReader.GetPuzzleInputs(ProblemNumber, 1, useSample);

        int safeReportCount = 0;

        foreach (string line in lines)
        {
            IEnumerable<string> splitLine = line.Split(' ');
            IEnumerable<int> report = splitLine.Select(s => int.Parse(s));



            bool safe = CheckReport(report);
            if (!safe)
            {
                var newReport = report.Skip(1);
                bool newSafe = CheckReport(newReport);
                if (!newSafe) { continue; }
            }

            safeReportCount++;
        }

        return safeReportCount.ToString();
    }

    private bool CheckReport(IEnumerable<int> report)
    {
        bool dampenerUsed = false;
        bool safeReport = true;

        bool ascending = report.ElementAt(0) < report.ElementAt(1);
        for (int i = 0; i < report.Count() - 1; i++)
        {
            int current = report.ElementAt(i);
            int next = report.ElementAt(i + 1);

            bool success = CheckAtTwoPoints(current, next, ascending);

            if (!success)
            {
                if (dampenerUsed)
                {
                    safeReport = false;
                    break;
                }

                if (i + 2 == report.Count())
                {
                    safeReport = false;
                    break;
                }

                int skipNext = report.ElementAt(i + 2);

                bool skipSuccess = CheckAtTwoPoints(current, skipNext, ascending);

                if (!skipSuccess)
                {
                    safeReport = false;
                    break;
                }

                i++;
            }
        }

        return safeReport;
    }

    private bool CheckAtTwoPoints(int a, int b, bool ascending)
    {
        bool ascendingNow = a < b;

        int distance = DistanceBetween(a, b);
        bool goodDistance = distance >= 1 && distance <= 3;

        return ascendingNow == ascending && goodDistance;
    }
}
