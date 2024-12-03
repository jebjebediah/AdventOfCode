using System.Diagnostics;
using System.Text.RegularExpressions;
using Common;
using Common.Helpers;

namespace Problems.Day01;

public class Main : IAdventOfCodeProblem
{
    public string ProblemNumber => "01";

    public async Task<string> RunPart1(bool useSample)
    {
        IEnumerable<string> lines = await PuzzleInputReader.GetPuzzleInputs(ProblemNumber, 1, useSample);

        List<int> sideAList = new List<int>();
        List<int> sideBList = new List<int>();

        foreach (string line in lines)
        {
            int lineLength = line.Length;

            string sideA = line.Substring(0, lineLength/2).TrimEnd();
            string sideB = line.Substring(lineLength/2).TrimStart();

            int parsedSideA = int.Parse(sideA);
            int parsedSideB = int.Parse(sideB);

            sideAList.Add(parsedSideA);
            sideBList.Add(parsedSideB);
        }

        List<int> sortedListA = sideAList.OrderByDescending(x => x).ToList();
        List<int> sortedListB = sideBList.OrderByDescending(x => x).ToList();

        int runningTotal = 0;

        for (int i = 0; i < sortedListA.Count; i++)
        {
            runningTotal += DistanceBetween(sortedListA.ElementAt(i), sortedListB.ElementAt(i));
        }

        return runningTotal.ToString();
    }

    private int DistanceBetween (int a, int b)
    {
        if (a > b)
        {
            return a - b;
        }
        else if (a < b)
        {
            return b - a;
        }
        else
        {
            return 0;
        }
    }

    public Task<string> RunPart2(bool useSample)
    {
        throw new NotImplementedException();
    }
}
