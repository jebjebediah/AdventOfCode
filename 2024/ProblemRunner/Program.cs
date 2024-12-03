using Common;

List<IAdventOfCodeProblem> problems = [
    new Problems.Day01.Main(),
];

bool sample = false;

foreach (IAdventOfCodeProblem problem in problems)
{
    string part1Result;
    try
    {
        part1Result = await problem.RunPart1(sample);
    }
    catch (NotImplementedException)
    {
        part1Result = "Not implemented yet";
    }

    Console.WriteLine($"{problem.ProblemNumber}.1 - {part1Result}");

    string part2Result;
    try
    {
        part2Result = await problem.RunPart2(sample);
    }
    catch (NotImplementedException)
    {
        part2Result = "Not implemented yet";
    }

    Console.WriteLine($"{problem.ProblemNumber}.2 - {part2Result}");
}