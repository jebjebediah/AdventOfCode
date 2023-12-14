using System.Diagnostics;
using Common;

List<IAdventOfCodeProblem> problems = [
    new Problems.Day01.Main(),
    new Problems.Day02.Main(),
    new Problems.Day03.Main(),
    //new Problems.Day04.Main(),
    new Problems.Day05.Main()
];

bool sample = false;

foreach (IAdventOfCodeProblem problem in problems)
{
    Stopwatch stopWatch1 = new Stopwatch();
    string part1Result;
    try
    {
        stopWatch1.Start();
        part1Result = await problem.RunPart1(sample);
        stopWatch1.Stop();
    }
    catch (NotImplementedException)
    {
        part1Result = "Not implemented yet";
    }

    Console.WriteLine($"{problem.ProblemNumber}.1 - {part1Result} - {stopWatch1.Elapsed}");

    Stopwatch stopWatch2 = new Stopwatch();
    string part2Result;
    try
    {
        stopWatch2.Start();
        part2Result = await problem.RunPart2(sample);
        stopWatch2.Stop();
    }
    catch (NotImplementedException)
    {
        part2Result = "Not implemented yet";
    }

    Console.WriteLine($"{problem.ProblemNumber}.2 - {part2Result} - {stopWatch2.Elapsed}");
}