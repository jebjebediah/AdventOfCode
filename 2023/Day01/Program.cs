using Common.Helpers;

IEnumerable<string> lines = await PuzzleInputReader.GetPuzzleInputs();

List<int> twoDigitNums = new();

foreach (string line in lines)
{
    List<int> digits = new List<int>();

    foreach (char c in line)
    {
        if (char.IsDigit(c))
        {
            digits.Add((int)char.GetNumericValue(c));
        }
    }

    int numA = digits.First();
    int numB = digits.Last();

    int newNum = (numA * 10) + numB;

    twoDigitNums.Add(newNum);
}

Console.WriteLine(twoDigitNums.Sum());