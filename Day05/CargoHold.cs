using System.Text;

namespace Day05
{
    internal class CargoHold
    {
        private List<Stack<char>> cargoStacks;

        public CargoHold(int width)
        {
            cargoStacks = new();

            for (int i = 0; i < width; i++)
            {
                cargoStacks.Add(new Stack<char>());
            }
        }

        public void AddToStack(int index, char c)
        {
            cargoStacks.ElementAt(index).Push(c);
        }

        private char RemoveFromStack(int index)
        {
            return cargoStacks.ElementAt(index).Pop();
        }

        public void DoMove(int fromIndex, int toIndex, int count)
        {
            Stack<char> movingItems = new Stack<char>();

            for (int i = 0; i < count; i++)
            {
                movingItems.Push(RemoveFromStack(fromIndex));
            }

            while (movingItems.Count > 0)
            {
                AddToStack(toIndex, movingItems.Pop());
            }
        }

        public string GetTop()
        {
            StringBuilder sb = new StringBuilder();
            
            foreach (Stack<char> stack in cargoStacks)
            {
                sb.Append(stack.Peek());
            }

            return sb.ToString();
        }
    }
}
