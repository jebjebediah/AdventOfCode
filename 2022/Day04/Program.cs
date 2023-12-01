using Common.Helpers;
using Day04;
using System.Text.RegularExpressions;

IEnumerable<string> lines = await PuzzleInputReader.GetPuzzleInputs();

int nestingCount = 0;
int overlappingCount = 0;

Regex regex = new Regex(@"(\d+)-(\d+),(\d+)-(\d+)");

foreach (var line in lines)
{
    Match match = regex.Match(line);

    if (match.Success)
    {
        int min1 = int.Parse(match.Groups[1].Value);
        int max1 = int.Parse(match.Groups[2].Value);
        int min2 = int.Parse(match.Groups[3].Value);
        int max2 = int.Parse(match.Groups[4].Value);

        if (AssignmentsHelper.NestingExists(min1, max1, min2, max2)) nestingCount++;
        if (AssignmentsHelper.OverlappingExists(min1, max1, min2, max2)) overlappingCount++;
    }
    else
    {
        throw new ArgumentException();
    }
}

Console.WriteLine(nestingCount);
Console.WriteLine(overlappingCount);