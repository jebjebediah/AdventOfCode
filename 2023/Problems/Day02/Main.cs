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

            string[] handfuls = dataPart.Split(';');

            bool gameIsPossible = true;
            foreach (string handful in handfuls)
            {
                bool handIsPossible = true;
                string[] counts = handful.Split(',');

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

    public Task<string> RunPart2(bool useSample)
    {
        throw new NotImplementedException();
    }
}
