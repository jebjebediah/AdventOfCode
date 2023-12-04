using System.Text.RegularExpressions;
using Common;
using Common.Helpers;

namespace Problems.Day03;

public class Main : IAdventOfCodeProblem
{
    public string ProblemNumber => "03";

    public async Task<string> RunPart1(bool useSample)
    {
        List<string> lines = (await PuzzleInputReader.GetPuzzleInputs(ProblemNumber, 1, useSample)).ToList();

        int partSum = 0;

        Regex numberRegex = new Regex(@"\d+");

        for (int i = 0; i < lines.Count; i++)
        {
            string line = lines.ElementAt(i);

            MatchCollection matches = numberRegex.Matches(line);

            foreach (Match match in matches)
            {
                for (int j = 0; j < match.Length; j++)
                {
                    if (TouchingSymbol(i, match.Index + j, lines))
                    {
                        partSum += int.Parse(match.Value);
                        break;
                    }
                }
            }
        }

        return partSum.ToString();
    }

    public Task<string> RunPart2(bool useSample)
    {
        throw new NotImplementedException();
    }

    private static bool IsSymbol(char c)
    {
        return !char.IsNumber(c) && !c.Equals('.');
    }

    private bool TouchingSymbol(int row, int column, List<string> lines)
    {
        return CheckAbove(row, column, lines) ||
               CheckBelow(row, column, lines) ||
               CheckLeft(row, column, lines) ||
               CheckRight(row, column, lines) ||
               CheckUpLeft(row, column, lines) ||
               CheckUpRight(row, column, lines) ||
               CheckLowLeft(row, column, lines) ||
               CheckLowRight(row, column, lines);
    }   

    private bool CheckAbove(int row, int column, List<string> lines)
    {
        if (row == 0)
        {
            return false;
        }

        char aboveChar = lines.ElementAt(row - 1).ElementAt(column);
        return IsSymbol(aboveChar);
    }

    private bool CheckBelow(int row, int column, List<string> lines)
    {
        if (row == lines.Count - 1)
        {
            return false;
        }

        char belowChar = lines.ElementAt(row + 1).ElementAt(column);
        return IsSymbol(belowChar);
    }

    private bool CheckLeft(int row, int column, List<string> lines)
    {
        if (column == 0)
        {
            return false;
        }

        char leftChar = lines.ElementAt(row).ElementAt(column - 1);
        return IsSymbol(leftChar);
    }

    private bool CheckRight(int row, int column, List<string> lines)
    {
        if (column == lines.ElementAt(0).Count() - 1)
        {
            return false;
        }

        char rightChar = lines.ElementAt(row).ElementAt(column + 1);
        return IsSymbol(rightChar);
    }

    private bool CheckUpLeft(int row, int column, List<string> lines)
    {
        if (row == 0 || column == 0)
        {
            return false;
        }

        char upLeftChar = lines.ElementAt(row - 1).ElementAt(column - 1);
        return IsSymbol(upLeftChar);
    }

    private bool CheckUpRight(int row, int column, List<string> lines)
    {
        if (row == 0 || column == lines.ElementAt(0).Count() - 1)
        {
            return false;
        }

        char upRightChar = lines.ElementAt(row - 1).ElementAt(column + 1);
        return IsSymbol(upRightChar);
    }

    private bool CheckLowLeft(int row, int column, List<string> lines)
    {
        if (row == lines.Count - 1 || column == 0)
        {
            return false;
        }

        char lowLeftChar = lines.ElementAt(row + 1).ElementAt(column - 1);
        return IsSymbol(lowLeftChar);
    }

    private bool CheckLowRight(int row, int column, List<string> lines)
    {
        if (row == lines.Count - 1 || column == lines.ElementAt(0).Count() - 1)
        {
            return false;
        }

        char lowRightChar = lines.ElementAt(row + 1).ElementAt(column + 1);
        return IsSymbol(lowRightChar);
    }
}
