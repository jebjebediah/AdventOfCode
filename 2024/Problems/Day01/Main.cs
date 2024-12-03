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

        SeparateIntoTwoLists(lines, out IList<int> sideAList, out IList<int> sideBList);

        List<int> sortedListA = sideAList.OrderByDescending(x => x).ToList();
        List<int> sortedListB = sideBList.OrderByDescending(x => x).ToList();

        int runningTotal = 0;

        for (int i = 0; i < sortedListA.Count; i++)
        {
            runningTotal += DistanceBetween(sortedListA.ElementAt(i), sortedListB.ElementAt(i));
        }

        return runningTotal.ToString();
    }

    private int DistanceBetween(int a, int b)
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

    private void SeparateIntoTwoLists(IEnumerable<string> lines, out IList<int> listA, out IList<int> listB)
    {
        listA = new List<int>();
        listB = new List<int>();

        foreach (string line in lines)
        {
            int lineLength = line.Length;

            string sideA = line.Substring(0, lineLength/2).TrimEnd();
            string sideB = line.Substring(lineLength/2).TrimStart();

            int parsedSideA = int.Parse(sideA);
            int parsedSideB = int.Parse(sideB);

            listA.Add(parsedSideA);
            listB.Add(parsedSideB);
        }
    }

    public async Task<string> RunPart2(bool useSample)
    {
        IEnumerable<string> lines = await PuzzleInputReader.GetPuzzleInputs(ProblemNumber, 1, useSample);

        SeparateIntoTwoLists(lines, out IList<int> sideAList, out IList<int> sideBList);

        Dictionary<int, int> foundDict = new Dictionary<int, int>();

        foreach (int value in sideAList)
        {
            if (!foundDict.ContainsKey(value))
            {
                foundDict.Add(value, 0);
            }
        }

        foreach (int value in sideBList)
        {
            if (foundDict.TryGetValue(value, out int valuevalue) == true)
            {
                foundDict[value] = valuevalue + 1;
            }
        }

        int runningTotal = 0;

        foreach (int value in sideAList)
        {
            runningTotal += value * foundDict[value];
        }

        return runningTotal.ToString();
    }
}
