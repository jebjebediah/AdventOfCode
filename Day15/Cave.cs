namespace Day15
{
    public class Cave
    {
        private List<Sensor> Sensors;

        public Cave()
        {
            Sensors = new List<Sensor>();
        }

        public void AddSensor(int xPos, int yPos, int xBeacon, int yBeacon)
        {
            Sensors.Add(new Sensor(xPos, yPos, xBeacon, yBeacon));
        }

        public int FilledAtYRow(int yRow)
        {
            int filledCount = 0;

            foreach (Sensor sensor in Sensors)
            {
                filledCount += sensor.OccupiedAtYRow(yRow);
            }

            return filledCount;
        }
    }

    internal struct CavePosition
    {
        internal int X;
        internal int Y;
    }

    internal struct Sensor
    {
        internal CavePosition Position;
        internal CavePosition NearestBeaconPosition;
        internal int RadiusToBeacon;
        
        internal Sensor(int xPos, int yPos, int xBeacon, int yBeacon)
        {
            Position = new CavePosition
            {
                X = xPos,
                Y = yPos
            };

            NearestBeaconPosition = new CavePosition
            {
                X = xBeacon,
                Y = yBeacon
            };

            RadiusToBeacon = int.Abs(NearestBeaconPosition.X - Position.X) +
                             int.Abs(NearestBeaconPosition.Y - Position.Y);
        }

        internal bool RadiusContainsYRow(int yRow)
        {
            return Position.Y + RadiusToBeacon >= yRow || Position.Y - RadiusToBeacon <= yRow;
        }

        internal IEnumerable<int> OccupiedAtYRow(int yRow)
        {
            // TODO: Double-counting
            int distanceFromRow = int.Abs(Position.Y - yRow);

            int maxDiameter = (2 * RadiusToBeacon) + 1;

            int radiusAtRow = RadiusToBeacon - distanceFromRow;

            int minX = Position.X - radiusAtRow;
            int maxX = Position.X + radiusAtRow;

            List<int> xPositions = new List<int>();

            for (int i = minX; i <= maxX; i++)
            {
                if (!(NearestBeaconPosition.Y == yRow && NearestBeaconPosition.X == i))
                {
                    xPositions.Add(i);
                }
            }

            int diameterAtRow = maxDiameter - (2 * distanceFromRow);

            if (NearestBeaconPosition.Y == yRow)
            {
                diameterAtRow--;
            }

            return xPositions;
        }
    }
}
