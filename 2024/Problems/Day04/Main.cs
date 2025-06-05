using System.Text;
using System.Text.RegularExpressions;
using Common;
using Common.Helpers;

namespace Problems.Day04;

public class Main : IAdventOfCodeProblem
{
    public string ProblemNumber => "04";

    public async Task<string> RunPart1(bool useSample)
    {
        List<string> lines = (await PuzzleInputReader.GetPuzzleInputs(ProblemNumber, 1, useSample)).ToList();

        string searchTerm = "XMAS";

        int totalMatches = 0;

        // Check the horizontal lines
        foreach (string line in lines)
        {
            totalMatches += SearchLine(line, searchTerm);
        }

        // Check the vertical lines
        for (int i = 0; i < lines.ElementAt(0).Length; i++) // Check for off-by-one here
        {
            StringBuilder sbVerticalLine = new StringBuilder();
            for (int j = 0; j < lines.Count; j++) // Check for off-by-one here
            {
                sbVerticalLine.Append(lines.ElementAt(j).ElementAt(i));
            }

            string verticalLine = sbVerticalLine.ToString();
            totalMatches += SearchLine(verticalLine, searchTerm);
        }

        // Check the diagonals... NW to SE
        IEnumerable<string> nwSeDiagonals = GetDiagonals(lines);
        IEnumerable<string> neSwDiagonals = GetDiagonals(lines.Select(line => new string(line.Reverse().ToArray())).ToList());

        List<string> diagonals = nwSeDiagonals.Concat(neSwDiagonals).ToList();
        foreach (string diagonal in diagonals)
        {
            totalMatches += SearchLine(diagonal, searchTerm);
        }

        return totalMatches.ToString();
    }

    private char GetLetterAtCoordinate(IEnumerable<string> lines, int x, int y)
    {
        return lines.ElementAt(y).ElementAt(x);
    }

    private IEnumerable<string> GetDiagonals(List<string> lines)
    {
        for (int i = 0; i < lines.ElementAt(0).Length; i++)
        {
            int x = i;
            int y = 0;

            StringBuilder sbDiagonal = new();

            do
            {
                sbDiagonal.Append(GetLetterAtCoordinate(lines, x, y));
                x++;
                y++;
            } while (lines.Count - 1 >= y && lines.ElementAt(y).Length > x);

            yield return sbDiagonal.ToString();
        }

        for (int i = 1; i < lines.Count; i++)
        {
            int x = 0;
            int y = i;

            StringBuilder sbDiagonal = new();
            do
            {
                sbDiagonal.Append(GetLetterAtCoordinate(lines, x, y));
                x++;
                y++;
            } while (lines.Count - 1 >= y && lines.ElementAt(y).Length > x);

            yield return sbDiagonal.ToString();
        }
    }

    private int SearchLine(string line, string searchTerm)
    {
        Regex regex = new Regex(searchTerm);
        MatchCollection matches = regex.Matches(line);
        int matchCount = matches.Count;

        Regex reversedRegex = new Regex(new string(searchTerm.Reverse().ToArray()));
        MatchCollection reversedMatches = reversedRegex.Matches(line);
        matchCount += reversedMatches.Count;
        return matchCount;
    }

    public Task<string> RunPart2(bool useSample)
    {
        throw new NotImplementedException();
    }
}
