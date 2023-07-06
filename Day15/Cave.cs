namespace Day15
{
    public class Cave
    {
        public AddSensor(int xPos, int yPos, int xBeacon, int yBeacon)
        {

        }
    }

    private struct CavePosition
    {
        int X;
        int Y;

        internal int DistanceTo(CavePosition other)
        {
            return int.Abs(this.X - end.X) + int.Abs(this.Y - end.Y);
        }
    }
}
