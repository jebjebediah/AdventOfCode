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

            SandSource = new CavePosition
            {
                X = sandSource.x,
                Depth = sandSource.depth
            };
        }

        public void SetFloor()
        {
            floorDepth = deepestOverallDepth + 2;
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
            bool aboveVoid = true;
            while (aboveVoid)
            {
                CavePosition sandLocation = SandSource;
                while (sandLocation.Depth < deepestOverallDepth)
                {
                    if (sandLocation.Depth == int.MaxValue)
                    {
                        throw new Exception();
                    }
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
                        CaveSpaces.Add(sandLocation, ECaveContent.Sand);
                        break;
                    }
                }

                restedCount++;

                if (sandLocation == SandSource)
                {
                    return restedCount;
                }
            }

            return restedCount;
        }

        private bool SpaceAvailable(CavePosition space)
        {
            bool atFloor = space.Depth == floorDepth - 1;

            return !atFloor && (CaveSpaces.ContainsKey(space) && CaveSpaces[space] == ECaveContent.Empty) || !CaveSpaces.ContainsKey(space);
        }
    }

    enum ECaveContent
    {
        Empty,
        Rock,
        Sand
    }

    struct CavePosition : IComparable
    {
        public int X;
        public int Depth;

        public CavePosition(int x, int depth)
        {
            this.X = x;
            this.Depth = depth;
        }

        public CavePosition Below()
        {
            return new CavePosition
            {
                X = this.X,
                Depth = this.Depth + 1
            };
        }

        public CavePosition BelowLeft()
        {
            return new CavePosition
            {
                X = this.X - 1,
                Depth = this.Depth + 1
            };
        }

        public CavePosition BelowRight()
        {
            return new CavePosition
            {
                X = this.X + 1,
                Depth = this.Depth + 1
            };
        }

        public int CompareTo(CavePosition otherPosition)
        {
            return (this.X == otherPosition.X && this.Depth == otherPosition.Depth) as int;
        }
    }
}