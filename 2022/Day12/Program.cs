using Common.Helpers;
using Day12;

internal class Program
{
    private static async Task Main(string[] args)
    {
        IEnumerable<string> lines = await PuzzleInputReader.GetPuzzleInputs();

        List<List<Node>> fieldNodes = new();

        for (int row = 0; row < lines.Count(); row++)
        {
            string line = lines.ElementAt(row);

            List<Node> currentRowNodes = new();

            for (int col = 0; col < line.Length; col++)
            {
                char step = line.ElementAt(col);

                if (step == 'E')
                {
                    Node newNode = new Node
                    {
                        Height = GetIntEquivalent('z'),
                        IsEnd = true
                    };
                    currentRowNodes.Add(newNode);
                }
                else if (step == 'S')
                {
                    Node newNode = new Node
                    {
                        Height = GetIntEquivalent('a'),
                    };
                    currentRowNodes.Add(newNode);
                }
                else
                {
                    Node newNode = new Node
                    {
                        Height = GetIntEquivalent(step)
                    };
                    currentRowNodes.Add(newNode);
                }
            }

            fieldNodes.Add(currentRowNodes);
        }

        List<Node> graphNodes = CreateGraph(fieldNodes).ToList();
        List<Node> lowestSpots = graphNodes.Where(n => n.Height == 1).ToList();

        int bestSoFar = int.MaxValue;
        foreach (Node start in lowestSpots)
        {
            int thisRun = BreadthFirstSearch(start);

            if (thisRun < bestSoFar) bestSoFar = thisRun;

            ResetBFS(graphNodes);
        }

        Console.WriteLine($"Min steps of all possible starts: {bestSoFar}");
    }

    private static int BreadthFirstSearch(Node startingNode)
    {
        Queue<Node> bfsQueue = new();
        bfsQueue.Enqueue(startingNode);

        while (bfsQueue.Any())
        {
            Node currentNode = bfsQueue.Dequeue();

            if (currentNode.IsEnd)
            {
                return currentNode.Distance;
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

        return int.MaxValue;
    }

    private static void ResetBFS(List<Node> graph)
    {
        foreach (Node node in graph.Where(n => n.Visited = true || n.Distance != 0 ))
        {
            node.Visited = false;
            node.Distance = 0;
        }
    }

    private static int GetIntEquivalent(char heightChar)
    {
        return heightChar - 96;
    }

    private static IEnumerable<Node> CreateGraph(IEnumerable<IEnumerable<Node>> field)
    {
        List<Node> flattenedList = new();

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

            flattenedList.AddRange(currentRow);
        }

        return flattenedList;
    }

    private static void ConnectIfPossible(Node currentNode, Node otherNode)
    {
        if (otherNode.Height - currentNode.Height <= 1)
        {
            currentNode.Edges.Add(otherNode);
        }
    }
}