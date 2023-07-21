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

        public IEnumerable<int> FilledAtYRow(int yRow)
        {
            HashSet<int> filledSpots = new HashSet<int>();

            foreach (Sensor sensor in Sensors)
            {
                IEnumerable<int> occupiedXs = sensor.OccupiedAtYRow(yRow);

                filledSpots.UnionWith(occupiedXs);
            }

            return filledSpots;
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
            int distanceFromRow = int.Abs(Position.Y - yRow);
            int radiusAtRow = RadiusToBeacon - distanceFromRow;

            if (radiusAtRow < 0)
            {
                return Enumerable.Empty<int>();
            }

            int minX = Position.X - radiusAtRow;
            int maxX = Position.X + radiusAtRow;

            CavePosition NearestBeacon = NearestBeaconPosition;

            int count = int.Abs(maxX - minX) + 1;
            int starting = Math.Min(minX, maxX);

            return Enumerable.Range(starting, count).Where(i => !(NearestBeacon.Y == yRow && NearestBeacon.X == i));
        }
    }
}
