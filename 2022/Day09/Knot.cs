namespace Day09
{
    public class Knot
    {
        public int xPos;
        public int yPos;

        public List<(int, int)> positions;

        public Knot()
        {
            xPos = 0;
            yPos = 0;
            positions = new();
        }

        public void AddCurrentPosition()
        {
            positions.Add((xPos, yPos));
        }

        public int GetUniquePositions()
        {
            return positions.Distinct().Count();
        }

        public bool IsTouching(Knot otherKnot)
        {
            bool touchingHorizontally = Math.Abs(this.xPos - otherKnot.xPos) <= 1.0;
            bool touchingVertically = Math.Abs(this.yPos - otherKnot.yPos) <= 1.0;

            return touchingVertically && touchingHorizontally;
        }

        public bool IsDirectlyBelow(Knot otherKnot)
        {
            return this.IsSameColumn(otherKnot) && this.yPos < otherKnot.yPos;
        }

        public bool IsDirectlyAbove(Knot otherKnot)
        {
            return this.IsSameColumn(otherKnot) && this.yPos > otherKnot.yPos;
        }

        public bool IsSameColumn(Knot otherKnot)
        {
            return this.xPos == otherKnot.xPos;
        }

        public bool IsDirectlyLeft(Knot otherKnot)
        {
            return this.IsSameRow(otherKnot) && this.xPos < otherKnot.xPos;
        }

        public bool IsDirectlyRight(Knot otherKnot)
        {
            return this.IsSameRow(otherKnot) && this.xPos > otherKnot.xPos;
        }

        public bool IsSameRow(Knot otherKnot)
        {
            return this.yPos == otherKnot.yPos;
        }

        public void Move(EDirection direction)
        {
            switch (direction)
            {
                case EDirection.Up:
                    this.yPos++;
                    break;
                case EDirection.Down:
                    this.yPos--;
                    break;
                case EDirection.Left:
                    this.xPos--;
                    break;
                case EDirection.Right:
                    this.xPos++;
                    break;
            }
        }
    }

    public enum EDirection
    {
        Up,
        Down,
        Left,
        Right
    }
}