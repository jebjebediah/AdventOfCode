using System.Collections.Generic;
using Common;
using Common.Helpers;

namespace Problems.Day01;

public class Main : IAdventOfCodeProblem
{
    public string ProblemNumber => "01";

    public async Task<string> RunPart1(bool useSample)
    {
        IEnumerable<string> lines = await PuzzleInputReader.GetPuzzleInputs(ProblemNumber, 1, useSample);

        int currPos = 50;
        int zeroedStops = 0;

        const string POSTURN = "R";
        const string NEGTURN = "L";

        foreach (string line in lines)
        {
            string direction = line[0].ToString();
            string numberPart = line[1..];
            int clicks = int.Parse(numberPart);

            if (direction.Equals(POSTURN))
            {
                currPos += clicks;
            }
            else if (direction.Equals(NEGTURN))
            {
                currPos -= clicks;
            }

            if (currPos % 100 == 0)
                zeroedStops++;
        }

        return zeroedStops.ToString();
    }

    public Task<string> RunPart2(bool useSample)
    {
        throw new NotImplementedException();
    }
}
