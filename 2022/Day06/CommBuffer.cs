namespace Day06
{
    internal class CommBuffer
    {
        private Queue<char> buffer;
        private int bufferSize;

        public CommBuffer(int bufferSize)
        {
            buffer = new Queue<char>();
            this.bufferSize = bufferSize;
        }

        public void AddToBuffer(char c)
        {
            buffer.Enqueue(c);
            if (buffer.Count > bufferSize)
            {
                buffer.Dequeue();
            }
        }

        public bool CheckForPacket()
        {
            if (buffer.Count == bufferSize)
            {
                IEnumerable<char> characters = buffer.Distinct();
                if (characters.Count() == bufferSize)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
