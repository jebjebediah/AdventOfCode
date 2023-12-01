namespace Day10
{
    public class CRT
    {
        private int cycleNumber;
        private int xReg;
        private string currentLine;
        private List<int> signalStrengths;

        public CRT()
        {
            cycleNumber = 1;
            xReg = 1;
            currentLine = string.Empty;
            signalStrengths = new();
        }

        public void Noop()
        {
            RecordSignalStrength();
            DrawPixel();

            cycleNumber++;
        }

        public void Addx(int argument)
        {
            RecordSignalStrength();
            DrawPixel();

            cycleNumber++;

            RecordSignalStrength();
            DrawPixel();

            cycleNumber++;

            xReg += argument;

        }

        private void RecordSignalStrength()
        {
            signalStrengths.Add(xReg * cycleNumber);
        }

        public int GetSignalStrengthAtCycle(int cycleNumber)
        {
            return signalStrengths.ElementAt(cycleNumber - 1);
        }

        private void DrawPixel()
        {   
            int cycleMod = cycleNumber % 40;

            if (cycleMod >= xReg && cycleMod <= xReg + 2)
            {
                currentLine = currentLine + "#";
            }
            else
            {
                currentLine = currentLine + ".";
            }

            if (currentLine.Length == 40)
            {
                Console.WriteLine(currentLine);
                currentLine = string.Empty;
            }
        }
    }
}