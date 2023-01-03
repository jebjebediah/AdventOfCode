using System.Text;
using Common.Helpers;
using Day13;

internal class Program
{
    private static async Task Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        IEnumerable<string> lines = await PuzzleInputReader.GetPuzzleInputs();
        IEnumerator<string> lineEnumerator = lines.GetEnumerator();

        int pairIndex = 1;
        int validSum = 0;

        while (lineEnumerator.MoveNext())
        {
            string lhs = lineEnumerator.Current;
            lineEnumerator.MoveNext();
            string rhs = lineEnumerator.Current;
            if ValidPair(lhs, rhs)
            {
                validSum += pairIndex;
                validSum += (pairIndex + 1);
            }

            pairIndex += 2;
        }

    }

    private static bool ValidPair(string lhs, string rhs)
    {
        Stack<List<int>> stack = new();

        IEnumerator<char> enumerator = lhs.GetEnumerator();

        StringBuilder sb = new StringBuilder();

        while (enumerator.MoveNext())
        {
            char current = enumerator.Current;

            if (current == '[')
            {
                stack.Push(new List<int>());
                ReadUntilCompleteList(enumerator, stack);
            }

            if (char.IsNumber(current))
            {
                sb.Append(current);
            }
            else if (current == ',')
            {
                if (sb.Length != 0)
                {
                    stack.Peek().Add(int.Parse(sb.ToString()));
                    sb.Clear();
                }
            }
            else if (current == ']')
            {
                if (sb.Length != 0)
                {
                    stack.Peek().Add(int.Parse(sb.ToString()));
                    sb.Clear();
                }
                // Perform analysis

                if (!Comparator.CompareLists(stack.Pop(), rhsStack.Pop()))
                {
                    return false;
                }

                stack.Pop();
            }
        }

        return true;
    }

    private static void ReadUntilCompleteList(IEnumerator<char> enumerator, Stack<List<int>> stack)
    {
        StringBuilder sb = new();

        while (enumerator.MoveNext())
        {
            char current = enumerator.Current;

            if (char.IsNumber(current))
            {
                sb.Append(current);
            }
            else if (current == ',')
            {
                if (sb.Length != 0)
                {
                    stack.Peek().Add(int.Parse(sb.ToString()));
                    sb.Clear();
                }
            }
            else if (current == ']')
            {
                if (sb.Length != 0)
                {
                    stack.Peek().Add(int.Parse(sb.ToString()));
                    sb.Clear();
                }
                stack.Pop();
            }

        }
    }
}