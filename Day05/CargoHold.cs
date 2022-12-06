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
            for (int i = 0; i < count; i++)
            {
                char movingCargo = RemoveFromStack(fromIndex);
                AddToStack(toIndex, movingCargo);
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
