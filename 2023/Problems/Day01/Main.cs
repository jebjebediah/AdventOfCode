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

            twoDigitNums.Add(CombineTwoNumerals(digits.First(), digits.Last()));
        }

        return twoDigitNums.Sum().ToString();
    }

    public async Task<string> RunPart2(bool useSample)
    {
        IEnumerable<string> lines = await PuzzleInputReader.GetPuzzleInputs(ProblemNumber, 2, useSample);

        List<int> twoDigitNums = [];

        foreach (string line in lines)
        {
            List<(int number, int position)> numsAtPositions = [];

            numsAtPositions.AddRange(GetNumeralsAtPositions(line));
            numsAtPositions.AddRange(GetNamesAtPositions(line));

            IEnumerable<(int number, int position)> orderedDigits = numsAtPositions.OrderBy(n => n.position);

            twoDigitNums.Add(CombineTwoNumerals(orderedDigits.First().number, orderedDigits.Last().number));
        }

        return twoDigitNums.Sum().ToString();
    }

    private static int CombineTwoNumerals(int tens, int ones)
    {
        return (tens * 10) + ones;
    }

    private static IEnumerable<(int number, int position)> GetNumeralsAtPositions(string line)
    {
        List<(int number, int position)> numeralsList = [];

        for (int i = 0; i < line.Length; i++)
        {
            char curr = line.ElementAt(i);

            if (char.IsDigit(curr))
            {
                numeralsList.Add(((int)char.GetNumericValue(curr), i));
            }
        }
        
        return numeralsList;
    }

    private static IEnumerable<(int number, int position)> GetNamesAtPositions(string line)
    {
        List<(string name, int number)> numerals = [("one", 1), ("two", 2), ("three", 3), ("four", 4), ("five", 5), ("six", 6), ("seven", 7), ("eight", 8), ("nine", 9)];

        List<(int number, int position)> numbersList = [];

        foreach ((string name, int number) numeral in numerals)
        {
            int index = -1;
            do
            {
                index = line.IndexOf(numeral.name, index + 1);
                if (index != -1)
                {
                    numbersList.Add((numeral.number, index));
                }
            } while (index != -1);
        }

        return numbersList;
    }
}