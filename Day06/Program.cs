using Common.Helpers;
using Day06;

IEnumerable<string> lines = await PuzzleInputReader.GetPuzzleInputs();

string line = lines.Single();

CommBuffer buffer = new CommBuffer(14);

int i = 1;
foreach (char c in line)
{
    buffer.AddToBuffer(c);
    if (buffer.CheckForPacket()) break;
    i++;
}

Console.WriteLine(i);
