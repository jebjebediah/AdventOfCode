namespace Common.Helpers;

public class PuzzleInputReader
{
    public static async Task<IEnumerable<string>> GetPuzzleInputs(string problemNumber, int part, bool isSample)
    {
        string basePath = Path.Combine(Environment.CurrentDirectory, "Inputs");

        string extension = isSample ? "sample" : "input";
        
        string finalPath;
        if (isSample)
        {
            string firstAttemptFileName = $"{problemNumber}.{part}.{extension}";
            var path = Path.Combine(basePath, firstAttemptFileName);
            if (File.Exists(path))
            {
                finalPath = path;
            }
            else
            {
                string secondAttemptFileName = $"{problemNumber}.{extension}";
                finalPath = Path.Combine(basePath, secondAttemptFileName);
            }
        }
        else
        {
            string fileName = $"{problemNumber}.{extension}";
            finalPath = Path.Combine(basePath, fileName);
        }

        string[] lines = await File.ReadAllLinesAsync(finalPath);

        return lines.ToList();
    }
}
