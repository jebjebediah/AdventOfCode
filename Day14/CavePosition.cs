namespace Day14
{
    internal struct CavePosition : IComparable<CavePosition>
    {
        public int X {set; get;}
        public int Depth {set; get;}

        public CavePosition(int x, int depth)
        {
            this.X = x;
            this.Depth = depth;
        }

        public CavePosition Below()
        {
            return new CavePosition(this.X, this.Depth + 1);
        }

        public CavePosition BelowLeft()
        {
            return new CavePosition(this.X - 1, this.Depth + 1);
        }

        public CavePosition BelowRight()
        {
            return new CavePosition(this.X + 1, this.Depth + 1);
        }

        public int CompareTo(CavePosition other)
        {
            return this.X == other.X && this.Depth == other.Depth ? 0 : 1;
        }
    }
}