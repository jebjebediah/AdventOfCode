namespace Common;

public interface IAdventOfCodeProblem
{
    public Task<string> RunPart1(bool useSample);
    public Task<string> RunPart2(bool useSample);

    public string ProblemNumber { get; }
}
