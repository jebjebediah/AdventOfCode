using Common;

namespace Test;

[TestClass]
public class ProblemTests
{
    private async Task CommonTestPart1(IAdventOfCodeProblem problem, string expected)
    {
        Assert.AreEqual(expected, await problem.RunPart1(true));
    }

    private async Task CommonTestPart2(IAdventOfCodeProblem problem, string expected)
    {
        Assert.AreEqual(expected, await problem.RunPart2(true));
    }
}