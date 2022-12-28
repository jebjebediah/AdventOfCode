using Common.Helpers;
using Day09;

IEnumerable<string> lines = await PuzzleInputReader.GetPuzzleInputs();

Rope rope = new Rope(10);

foreach (string line in lines)
{
    char direction = line.ElementAt(0);

    string numberSubString = line.Substring(2);

    int steps = int.Parse(numberSubString);

    while (steps > 0) {
        switch (direction)
        {
            case 'L':
                rope.MoveLeft();
                break;
            case 'R':
                rope.MoveRight();
                break;
            case 'U':
                rope.MoveUp();
                break;
            case 'D':
                rope.MoveDown();
                break;
        }

        steps--;
    }

}

Console.WriteLine($"Tail Positions: {rope.GetUniqueTailPos()}");
