namespace Problems.Day05;

public class RangeMapping
{
    public uint DestinationStart;
    public uint SourceStart;
    public uint RangeLength;

    public RangeMapping(string line)
    {
        var nums = line.Split(' ').Select(uint.Parse).ToList();

        DestinationStart = nums.ElementAt(0);
        SourceStart = nums.ElementAt(1);
        RangeLength = nums.ElementAt(2);

    }

    public bool IsWithinRange(uint seed)
    {
        return (seed >= SourceStart) && (seed <= SourceStart + RangeLength);
    }

    public uint RemappingOf(uint seed)
    {
        return DestinationStart + (seed - SourceStart);
    }
}
