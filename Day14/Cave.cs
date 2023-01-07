namespace Day14
{
    internal class Cave
    {
        private List<bool> blankLine;
        private List<List<bool>> caveSlice;  // true = occupied, false = open
        private const bool OccupiedSymbol = true;
        private const bool OpenSymbol = !OccupiedSymbol;
        private int deepestHorizontalLine;

        public Cave(int width)
        {
            caveSlice = new();

            List<bool> caveLine = new();
            for (int i = 0; i < 2 * width; i++) // Ok yeah I know this is iffy
            {
                caveLine.Add(OpenSymbol);
            }

            caveSlice.Add(caveLine);

            blankLine = caveLine;

            deepestHorizontalLine = 0;
        }

        public void PadCaveDepth(int targetDepth)
        {
            while (caveSlice.Count < targetDepth)
            {
                caveSlice.Add(blankLine);
            }
        }

        public void CreateLine((int X, int Y) startingPoint, (int X, int Y) endingPoint)
        {
            int furthestDepth = Math.Max(startingPoint.Y, endingPoint.Y);
            PadCaveDepth(furthestDepth);

            bool isHorizontal = false;
            if (startingPoint.Y == endingPoint.Y)
            {
                isHorizontal = true;
                deepestHorizontalLine = Math.Max(deepestHorizontalLine, startingPoint.Y);
            }

            if (isHorizontal)
            {
                for (int i = startingPoint.X; i < endingPoint.X; i++)
                {
                    caveSlice.ElementAt(startingPoint.Y)[i] = OccupiedSymbol;
                }
            }
            else 
            {
                for (int i = startingPoint.Y; i < endingPoint.Y; i++)
                {
                    caveSlice.ElementAt(i)[startingPoint.X] = OccupiedSymbol;
                }
            }
        }
    }
}