using System;
using System.Threading.Tasks;
using Common.Helpers;

internal class Program
{
    private static async Task Main(string[] args)
    {
        IEnumerable<string> lines = await PuzzleInputReader.GetPuzzleInputs();

        List<List<int>> forest = new();

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
            }
        }
        Console.WriteLine(totalVisible);
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
}