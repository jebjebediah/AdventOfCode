using Common.Helpers;
using Day12;

internal class Program
{
    private static async Task Main(string[] args)
    {
        IEnumerable<string> lines = await PuzzleInputReader.GetPuzzleInputs();

        List<List<Node>> fieldNodes = new();

        (int, int) startingPosition = (0, 0);

        for (int row = 0; row < lines.Count(); row++)
        {
            string line = lines.ElementAt(row);

            List<Node> currentRowNodes = new();

            for (int col = 0; col < line.Length; col++)
            {
                char step = line.ElementAt(col);

                Node newNode = new Node();

                if (step == 'E')
                {
                    newNode.Height = GetIntEquivalent('z');
                    newNode.IsEnd = true;
                    currentRowNodes.Add(newNode);
                }
                else if (step == 'S')
                {
                    startingPosition = (row, col);
                    newNode.Height = GetIntEquivalent('a');
                    currentRowNodes.Add(newNode);
                }
                else
                {
                    newNode.Height = GetIntEquivalent(step);
                    currentRowNodes.Add(newNode);
                }
            }

            fieldNodes.Add(currentRowNodes);
        }

        CreateGraph(fieldNodes);

        Node startingNode = fieldNodes.ElementAt(startingPosition.Item1).ElementAt(startingPosition.Item2);

        Queue<Node> bfsQueue = new();
        bfsQueue.Enqueue(startingNode);

        int steps = 0;
        while (bfsQueue.Any())
        {
            Node currentNode = bfsQueue.Dequeue();

            if (currentNode.IsEnd)
            {
                steps = currentNode.Distance;
                break;
            }

            currentNode.Visited = true;
            foreach (Node edge in currentNode.Edges)
            {
                if (!edge.Visited)
                {
                    edge.Visited = true;
                    edge.Distance = currentNode.Distance + 1;
                    bfsQueue.Enqueue(edge);
                }
            }
            
        }

        Console.WriteLine($"Min steps: {steps}");
    }

    private static int GetIntEquivalent(char heightChar)
    {
        return heightChar - 96;
    }

    private static void CreateGraph(IEnumerable<IEnumerable<Node>> field)
    {
        for (int row = 0; row < field.Count(); row++)
        {
            IEnumerable<Node> currentRow = field.ElementAt(row);

            for (int col = 0; col < currentRow.Count(); col++)
            {
                Node currentNode = currentRow.ElementAt(col);

                if (col != 0)
                {
                    //Left
                    Node otherNode = currentRow.ElementAt(col - 1);
                    ConnectIfPossible(currentNode, otherNode);
                }
                if (col != currentRow.Count() - 1)
                {
                    //Right
                    Node otherNode = currentRow.ElementAt(col + 1);
                    ConnectIfPossible(currentNode, otherNode);
                }
                if (row != 0)
                {
                    //Up
                    Node otherNode = field.ElementAt(row - 1).ElementAt(col);
                    ConnectIfPossible(currentNode, otherNode);
                }
                if (row != field.Count() - 1)
                {
                    //Down
                    Node otherNode = field.ElementAt(row + 1).ElementAt(col);
                    ConnectIfPossible(currentNode, otherNode);
                }
            }
        }
    }

    private static void ConnectIfPossible(Node currentNode, Node otherNode)
    {
        if (otherNode.Height - currentNode.Height <= 1)
        {
            currentNode.Edges.Add(otherNode);
        }
    }
}