namespace Day12
{
    public class Node
    {
        public int Height { get; set; }
        public List<Node> Edges { get; set; }
        public bool Visited { get; set; }
        public bool IsEnd { get; set; }
        public int Distance { get; set; }

        public Node()
        {
            Edges = new();
            Visited = false;
            IsEnd = false;
        }
    }
}