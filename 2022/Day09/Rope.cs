namespace Day09
{
    public class Rope
    {
        private List<Knot> knots;

        public Rope(int numKnots)
        {
            knots = new();

            for (int i = 0; i < numKnots; i++)
            {
                knots.Add(new Knot());
            }
        }

        public void MoveUp()
        {
            knots.First().yPos++;

            for (int i = 1; i < knots.Count; i++)
            {
                FollowLeader(knots.ElementAt(i - 1), knots.ElementAt(i));
            }
        }

        public void MoveDown()
        {
            knots.First().yPos--;
            
            for (int i = 1; i < knots.Count; i++)
            {
                FollowLeader(knots.ElementAt(i - 1), knots.ElementAt(i));
            }
        }

        public void MoveLeft()
        {
            knots.First().xPos--;

            for (int i = 1; i < knots.Count; i++)
            {
                FollowLeader(knots.ElementAt(i - 1), knots.ElementAt(i));
            }
        }

        public void MoveRight()
        {
            knots.First().xPos++;

            for (int i = 1; i < knots.Count; i++)
            {
                FollowLeader(knots.ElementAt(i - 1), knots.ElementAt(i));
            }
        }

        public int GetUniqueTailPos()
        {
            return knots.Last().GetUniquePositions();
        }

        public void FollowLeader(Knot leaderKnot, Knot currentKnot)
        {
            if (currentKnot.IsDirectlyAbove(leaderKnot))
            {
                while (!currentKnot.IsTouching(leaderKnot))
                {
                    currentKnot.Move(EDirection.Down);
                }
            }
            else if (currentKnot.IsDirectlyBelow(leaderKnot))
            {
                while (!currentKnot.IsTouching(leaderKnot))
                {
                    currentKnot.Move(EDirection.Up);
                }
            }
            else if (currentKnot.IsDirectlyLeft(leaderKnot))
            {
                while (!currentKnot.IsTouching(leaderKnot))
                {
                    currentKnot.Move(EDirection.Right);
                }
            }
            else if (currentKnot.IsDirectlyRight(leaderKnot))
            {
                while (!currentKnot.IsTouching(leaderKnot))
                {
                    currentKnot.Move(EDirection.Left);
                }
            }
            else if (!currentKnot.IsTouching(leaderKnot))
            {
                if (currentKnot.xPos < leaderKnot.xPos)
                {
                    currentKnot.Move(EDirection.Right);
                    if (currentKnot.yPos < leaderKnot.yPos)
                    {
                        currentKnot.Move(EDirection.Up);
                    }
                    else 
                    {
                        currentKnot.Move(EDirection.Down);
                    }
                }
                else if (currentKnot.xPos > leaderKnot.xPos)
                {
                    currentKnot.Move(EDirection.Left);
                    if (currentKnot.yPos < leaderKnot.yPos)
                    {
                        currentKnot.Move(EDirection.Up);
                    }
                    else 
                    {
                        currentKnot.Move(EDirection.Down);
                    }
                }
            }

            currentKnot.AddCurrentPosition();
        }
    }
}
