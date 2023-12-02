using Common.Helpers;
using Common;

namespace Problems.Day01;

public class Main : IAdventOfCodeProblem
{
    public string ProblemNumber => "01";

    public async Task<string> RunPart1(bool useSample)
    {
        IEnumerable<string> lines = await PuzzleInputReader.GetPuzzleInputs(ProblemNumber, 1, useSample);

        List<int> twoDigitNums = new();

        foreach (string line in lines)
        {
            List<int> digits = new List<int>();

            foreach (char c in line)
            {
                if (char.IsDigit(c))
                {
                    digits.Add((int)char.GetNumericValue(c));
                }
            }

            int numA = digits.First();
            int numB = digits.Last();

            int newNum = (numA * 10) + numB;

            twoDigitNums.Add(newNum);
        }

        return twoDigitNums.Sum().ToString();
    }

    public Task<string> RunPart2(bool useSample)
    {
        throw new NotImplementedException();
    }
}
