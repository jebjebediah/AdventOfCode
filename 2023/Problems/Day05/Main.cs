using Common;
using Common.Helpers;

namespace Problems.Day05;

public class Main : IAdventOfCodeProblem
{
    public string ProblemNumber => "05";

    public async Task<string> RunPart1(bool useSample)
    {
        List<string> lines = (await PuzzleInputReader.GetPuzzleInputs(ProblemNumber, 1, useSample)).ToList();

        string seedsLine = lines.ElementAt(0);

        IEnumerable<uint> seeds = GetSeeds(seedsLine);
        List<List<RangeMapping>> ranges = BuildTranslationRanges(lines.Skip(1));

        List<uint> finalSeedPositions = [];

        foreach (uint seed in seeds)
        {
            finalSeedPositions.Add(FindMappingForSeed(ranges, seed));
        }

        return finalSeedPositions.Min().ToString();
    }

    private static uint FindMappingForSeed(List<List<RangeMapping>> ranges, uint seed)
    {
        uint currentMapping = seed;

        foreach (List<RangeMapping> map in ranges)
        {
            foreach (RangeMapping entry in map)
            {
                if (entry.IsWithinRange(currentMapping))
                {
                    currentMapping = entry.RemappingOf(currentMapping);
                    break;
                }
            }
        }

        return currentMapping;
    }

    private static IEnumerable<uint> GetSeeds(string seedsLine)
    {
        string seedsList = seedsLine.Split(':').ElementAt(1).Trim();

        return seedsList.Split(' ').Select(uint.Parse);
    }

    private static List<List<RangeMapping>> BuildTranslationRanges(IEnumerable<string> lines)
    {
        List<List<RangeMapping>> translationRanges = [];

        foreach (string line in lines)
        {
            if (line.Contains(':'))
            {
                translationRanges.Add(new List<RangeMapping>());
            }
            else if (string.IsNullOrEmpty(line))
            {
                continue;
            }
            else
            {
                translationRanges.Last().Add(new RangeMapping(line));
            }
        }

        return translationRanges;
    }

    public Task<string> RunPart2(bool useSample)
    {
        throw new NotImplementedException();
    }
}
