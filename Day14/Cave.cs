namespace Day14
{
    internal class Cave
    {
        private int deepestOverallDepth;
        private int floorDepth;
        private Dictionary<CavePosition, ECaveContent> CaveSpaces;
        private CavePosition SandSource;

        public Cave((int x, int depth) sandSource)
        {
            CaveSpaces = new Dictionary<CavePosition, ECaveContent>();

            deepestOverallDepth = 0;

            SandSource = new CavePosition(sandSource.x, sandSource.depth);
        }

        public void CreateLine((int x, int depth) startingPoint, (int x, int depth) endingPoint)
        {
            int shallowestDepth = Math.Min(startingPoint.depth, endingPoint.depth);
            int deepestDepth = Math.Max(startingPoint.depth, endingPoint.depth);

            int leftmostX = Math.Min(startingPoint.x, endingPoint.x);
            int rightmostX = Math.Max(startingPoint.x, endingPoint.x);

            if (shallowestDepth == deepestDepth) // Horizontal line
            {
                if (deepestDepth > deepestOverallDepth)
                {
                    deepestOverallDepth = deepestDepth;
                    floorDepth = deepestOverallDepth + 2;
                }

                for (int i = leftmostX; i <= rightmostX; i++)
                {
                    FillIfEmpty((i, shallowestDepth));
                }
            }
            else // Vertical line
            {
                for (int i = shallowestDepth; i <= deepestDepth; i++)
                {
                    FillIfEmpty((leftmostX, i));
                }
            }
        }

        private void FillIfEmpty((int x, int depth) position)
        {
            CavePosition newPosition = new CavePosition(position.x, position.depth);
            if (SpaceAvailable(newPosition))
            {
                CaveSpaces.Add(newPosition, ECaveContent.Rock);
            }
        }

        public int EverythingFalls()
        {
            int restedCount = 0;
            bool holePlugged = false;
            while (!holePlugged)
            {
                CavePosition sandLocation = SandSource;
                
                while (!SpaceSitsOnFloor(sandLocation))
                {
                    if (SpaceAvailable(sandLocation.Below()))
                    {
                        sandLocation = sandLocation.Below();
                    }
                    else if (SpaceAvailable(sandLocation.BelowLeft()))
                    {
                        sandLocation = sandLocation.BelowLeft();
                    }
                    else if (SpaceAvailable(sandLocation.BelowRight()))
                    {
                        sandLocation = sandLocation.BelowRight();
                    }
                    else
                    {
                        break;
                    }
                }

                CaveSpaces.Add(sandLocation, ECaveContent.Sand);

                restedCount++;

                if (sandLocation.CompareTo(SandSource) == 0)
                {
                    holePlugged = true;
                }
            }

            return restedCount;
        }

        private bool SpaceAvailable(CavePosition space)
        {
            return (CaveSpaces.ContainsKey(space) && CaveSpaces[space] == ECaveContent.Empty) || !CaveSpaces.ContainsKey(space);
        }

        private bool SpaceSitsOnFloor(CavePosition space)
        {
            return space.Depth == floorDepth - 1;
        }
    }

    enum ECaveContent
    {
        Empty,
        Rock,
        Sand
    }
}