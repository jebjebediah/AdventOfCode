using System;
using System.Threading.Tasks;
using Common.Helpers;

internal class Program
{
    private static async Task Main(string[] args)
    {
        IEnumerable<string> lines = await PuzzleInputReader.GetPuzzleInputs();

        List<List<int>> forest = new();
        List<int> scores = new();

        int totalVisible = 0;

        foreach (string line in lines)
        {
            List<int> rowInts = new();
            List<bool> rowBools = new();

            foreach (char height in line)
            {
                rowInts.Add(Convert.ToInt32(char.GetNumericValue(height)));
                rowBools.Add(false);
            }

            forest.Add(rowInts);
        }

        for (int i = 0; i < forest.Count; i++)
        {
            List<int> row = forest.ElementAt(i);

            for (int j = 0; j < row.Count; j++)
            {    
                if (IsVisibleFromLeft(i, j, forest) || 
                    IsVisibleFromRight(i, j, forest) || 
                    IsVisibleFromTop(i, j, forest) || 
                    IsValidFromBottom(i, j, forest))
                {
                    totalVisible++;
                }

                int totalScore = ScenicScoreLeft(i, j, forest) * 
                                 ScenicScoreRight(i, j, forest) *
                                 ScenicScoreTop(i, j, forest) * 
                                 ScenicScoreBottom(i, j, forest);

                scores.Add(totalScore);
            }
        }
        Console.WriteLine($"Visible trees: {totalVisible}");
        Console.WriteLine($"Max scenic score: {scores.Max()}");
    }

    private static bool IsVisibleFromLeft(int row, int column, List<List<int>> forest)
    {
        for (int i = column - 1; i >= 0; i--)
        {
            if (forest.ElementAt(row).ElementAt(i) >= forest.ElementAt(row).ElementAt(column))
            {
                return false;
            }
        }

        return true;
    }

    private static bool IsVisibleFromRight(int row, int column, List<List<int>> forest)
    {
        for (int i = column + 1; i < forest.ElementAt(row).Count; i++)
        {
            if (forest.ElementAt(row).ElementAt(i) >= forest.ElementAt(row).ElementAt(column))
            {
                return false;
            }
        }

        return true;
    }

    private static bool IsVisibleFromTop(int row, int column, List<List<int>> forest)
    {
        for (int i = row - 1; i >= 0; i--)
        {
            if (forest.ElementAt(i).ElementAt(column) >= forest.ElementAt(row).ElementAt(column))
            {
                return false;
            }
        }

        return true;
    }

    private static bool IsValidFromBottom(int row, int column, List<List<int>> forest)
    {
        for (int i = row + 1; i < forest.Count; i++)
        {
            if (forest.ElementAt(i).ElementAt(column) >= forest.ElementAt(row).ElementAt(column))
            {
                return false;
            }
        }

        return true;
    }

    private static int ScenicScoreLeft(int row, int column, List<List<int>> forest)
    {
        int score = 0;
        int testHeight = forest.ElementAt(row).ElementAt(column);

        for (int i = column - 1; i >= 0; i--)
        {
            score++;
            int challengerHeight = forest.ElementAt(row).ElementAt(i);

            if (challengerHeight >= testHeight)
            {
                break;
            }
        }

        return score;
    }

    private static int ScenicScoreRight(int row, int column, List<List<int>> forest)
    {
        int score = 0;
        int testHeight = forest.ElementAt(row).ElementAt(column);

        for (int i = column + 1; i < forest.ElementAt(row).Count; i++)
        {
            score++;
            int challengerHeight = forest.ElementAt(row).ElementAt(i);

            if (challengerHeight >= testHeight)
            {
                break;
            }
        }

        return score;
    }

    private static int ScenicScoreTop(int row, int column, List<List<int>> forest)
    {
        int score = 0;
        int testHeight = forest.ElementAt(row).ElementAt(column);

        for (int i = row - 1; i >= 0; i--)
        {
            score++;
            int challengerHeight = forest.ElementAt(i).ElementAt(column);   

            if (challengerHeight >= testHeight)
            {
                break;
            }
        }

        return score;
    }

    private static int ScenicScoreBottom(int row, int column, List<List<int>> forest)
    {
        int score = 0;
        int testHeight = forest.ElementAt(row).ElementAt(column);

        for (int i = row + 1; i < forest.Count; i++)
        {
            score++;
            int challengerHeight = forest.ElementAt(i).ElementAt(column);

            if (challengerHeight >= testHeight)
            {
                break;
            }
        }

        return score;
    }
}