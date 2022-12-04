namespace Common.Helpers
{
    public class PuzzleInputReader
    {
        public static async Task<IEnumerable<string>> GetPuzzleInputs()
        {
            var path = Path.Combine(Environment.CurrentDirectory, "input.txt");

            string[] lines = await File.ReadAllLinesAsync(path.ToString());

            return lines.ToList();
        }
    }
}
