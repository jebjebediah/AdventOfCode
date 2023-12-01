namespace Common.Helpers;

public class PuzzleInputReader
{
    public static async Task<IEnumerable<string>> GetPuzzleInputs(string fileName = "input.txt")
    {
        var path = Path.Combine(Environment.CurrentDirectory, fileName);

        string[] lines = await File.ReadAllLinesAsync(path.ToString());

        return lines.ToList();
    }
}
