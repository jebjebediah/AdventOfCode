using System.Text.RegularExpressions;
using Common;
using Common.Helpers;

namespace Problems.Day02;

public class Main : IAdventOfCodeProblem
{
    public string ProblemNumber => "02";

    public async Task<string> RunPart1(bool useSample)
    {
        IEnumerable<string> lines = await PuzzleInputReader.GetPuzzleInputs(ProblemNumber, 1, useSample);

        const int redCount = 12;
        const int greenCount = 13;
        const int blueCount = 14;

        int gamesSum = 0;

        Regex numberRegex = new(@"\d+");

        foreach (string line in lines)
        {
            var initialParts =  line.Split(':');
            string gameLabel = initialParts.ElementAt(0);
            string dataPart = initialParts.ElementAt(1);

            int gameNumber = int.Parse(numberRegex.Match(gameLabel).Value);

            IEnumerable<string> handfuls = GetHandfulsFromGame(dataPart);

            bool gameIsPossible = true;
            foreach (string handful in handfuls)
            {
                bool handIsPossible = true;
                var counts = GetCountsFromHandful(handful);

                foreach (string count in counts)
                {
                    string match = numberRegex.Match(count).Value;
                    int countNum = int.Parse(match);

                    if ((count.Contains("red") && countNum > redCount) ||
                        (count.Contains("blue") && countNum > blueCount) ||
                        (count.Contains("green") && countNum > greenCount))
                    {
                        handIsPossible = false;
                        break;
                    }
                }

                if (!handIsPossible)
                {
                    gameIsPossible = false;
                    break;
                }
            }

            if (gameIsPossible)
            {
                gamesSum += gameNumber;
            }
        }

        return gamesSum.ToString();
    }

    public async Task<string> RunPart2(bool useSample)
    {
        IEnumerable<string> lines = await PuzzleInputReader.GetPuzzleInputs(ProblemNumber, 2, useSample);

        Regex numberRegex = new(@"\d+");

        int totalPower = 0;

        foreach (string line in lines)
        {
            int maxRed = 0;
            int maxBlue = 0;
            int maxGreen = 0;

            var initialParts =  line.Split(':');

            IEnumerable<string> handfuls = GetHandfulsFromGame(initialParts.ElementAt(1));

            foreach (string handful in handfuls)
            {
                IEnumerable<string> counts = GetCountsFromHandful(handful);

                foreach (string count in counts)
                {
                    string match = numberRegex.Match(count).Value;
                    int countNum = int.Parse(match);

                    if (count.Contains("red"))
                    {
                        maxRed = Math.Max(maxRed, countNum);
                    }
                    else if (count.Contains("blue"))
                    {
                        maxBlue = Math.Max(maxBlue, countNum);
                    }
                    else if (count.Contains("green"))
                    {
                        maxGreen = Math.Max(maxGreen, countNum);
                    }
                }
            }

            totalPower += maxRed * maxGreen * maxBlue;
        }

        return totalPower.ToString();
    }

    private IEnumerable<string> GetHandfulsFromGame(string game)
    {
        return game.Split(';');
    }

    private IEnumerable<string> GetCountsFromHandful(string handful)
    {
        return handful.Split(',');
    }
}
