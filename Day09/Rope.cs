namespace Day09
{
    public class Rope
    {
        private int headXPos;
        private int headYPos;
        private int tailXPos;
        private int tailYPos;

        public Rope()
        {
            headXPos = 0;
            headYPos = 0;
            tailXPos = 0;
            tailYPos = 0;
            tailPositions = new();
        }

        private List<string> tailPositions;

        public void MoveUp()
        {
            headYPos++;

            if (!AreTouching())
            {
                tailYPos++;
                CorrectHorizontalAlignment();
            }

            tailPositions.Add($"{tailXPos} {tailYPos}");
        }

        public void MoveDown()
        {
            headYPos--;
            if (!AreTouching())
            {
                tailYPos--;
                CorrectHorizontalAlignment();
            }

            tailPositions.Add($"{tailXPos} {tailYPos}");
        }

        private void CorrectHorizontalAlignment()
        {
            if (headXPos != tailXPos)
            {
                tailXPos += (headXPos - tailXPos);
            }
        }

        public void MoveLeft()
        {
            headXPos--;
            if (!AreTouching())
            {
                tailXPos--;
                if (headYPos != tailYPos)
                {
                    tailYPos += (headYPos - tailYPos);
                }
            }

            tailPositions.Add($"{tailXPos} {tailYPos}");
        }

        public void MoveRight()
        {
            headXPos++;
            if (!AreTouching())
            {
                tailXPos++;
                CorrectVerticalAlignment();
            }

            tailPositions.Add($"{tailXPos} {tailYPos}");
        }

        private void CorrectVerticalAlignment()
        {
            if (headYPos != tailYPos)
            {
                tailYPos += (headYPos - tailYPos);
            }
        }

        private bool AreTouching()
        {
            bool touchingHorizontally = Math.Abs(headXPos - tailXPos) <= 1.0;
            bool touchingVertically = Math.Abs(headYPos - tailYPos) <= 1.0;

            return touchingVertically && touchingHorizontally;
        }

        public int GetUniqueTailPos()
        {
            return tailPositions.Distinct().Count();
        }
    }
}
