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

    [TestMethod]
    public async Task TestDay01Part1()
    {
        await CommonTestPart1(new Problems.Day01.Main(), "142");
    }

    [TestMethod]
    public async Task TestDay01Part2()
    {
        await CommonTestPart2(new Problems.Day01.Main(), "281");
    }

    [TestMethod]
    public async Task TestDay02Part1()
    {
        await CommonTestPart1(new Problems.Day02.Main(), "8");
    }

    [TestMethod]
    public async Task TestDay02Part2()
    {
        await CommonTestPart2(new Problems.Day02.Main(), "2286");
    }

    [TestMethod]
    public async Task TestDay03Part1()
    {
        await CommonTestPart1(new Problems.Day03.Main(), "4361");
    }

    [TestMethod]
    public async Task TestDay03Part2()
    {
        await CommonTestPart2(new Problems.Day03.Main(), "467835");
    }

    [TestMethod]
    public async Task TestDay04Part1()
    {
        await CommonTestPart1(new Problems.Day04.Main(), "13");
    }

    [TestMethod]
    public async Task TestDay04Part2()
    {
        await CommonTestPart2(new Problems.Day04.Main(), "30");
    }
}