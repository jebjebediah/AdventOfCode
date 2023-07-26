using System.Diagnostics;

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

        public CavePosition FindBeaconSpot(int min, int max)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            foreach (Sensor sensor in Sensors)
            {
                IEnumerable<CavePosition> positions = sensor.JustOutsideOfRange(min, max);

                foreach (CavePosition position in positions)
                {
                    bool insideOthers = false;

                    foreach (Sensor otherSensor in Sensors.Where(s => !s.Position.Equals(sensor.Position)))
                    {
                        if (DistanceBetween(position, otherSensor.Position) <= otherSensor.RadiusToBeacon)
                        {
                            insideOthers = true;
                            break;
                        }
                    }

                    if (!insideOthers)
                    {
                        stopWatch.Stop();
                        TimeSpan ts = stopWatch.Elapsed;

                        string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                            ts.Hours, ts.Minutes, ts.Seconds,
                            ts.Milliseconds / 10);
                        Console.WriteLine("RunTime " + elapsedTime);

                        return position;
                    }
                }
            }

            return new CavePosition(-1, -1);
        }

        public int DistanceBetween(CavePosition first, CavePosition second)
        {
            return int.Abs(first.X - second.X) + int.Abs(first.Y - second.Y);
        }

    }

    public struct CavePosition : IEquatable<CavePosition>
    {
        public int X;
        public int Y;
        public CavePosition(int x, int y)
        {
            X = x;
            Y = y;
        }
        public override bool Equals(object obj) =>
            (obj is CavePosition other) && Equals(other);

        public bool Equals(CavePosition other)
        {
            return (this.X == other.X) && (this.Y == other.Y);
        }

        public override int GetHashCode()
        {
            return (X, Y).GetHashCode();
        }
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

        internal IEnumerable<CavePosition> JustOutsideOfRange(int min, int max)
        {
            CavePosition leftPoint = new CavePosition(Position.X - RadiusToBeacon - 1, Position.Y);
            CavePosition rightPoint = new CavePosition(Position.X + RadiusToBeacon + 1, Position.Y);
            CavePosition topPoint = new CavePosition(Position.X, Position.Y + RadiusToBeacon + 1);
            CavePosition bottomPoint = new CavePosition(Position.X, Position.Y - RadiusToBeacon - 1);

            IEnumerable<CavePosition> nwRange = Enumerable.Range(0, topPoint.X - leftPoint.X).Select(i => new CavePosition(leftPoint.X + i, leftPoint.Y + i)).Where(p => (p.X >= min && p.X <= max) && (p.Y >= min && p.Y <= max));
            IEnumerable<CavePosition> neRange = Enumerable.Range(0, rightPoint.X - topPoint.X + 1).Select(i => new CavePosition(topPoint.X + i, topPoint.Y - i)).Where(p => (p.X >= min && p.X <= max) && (p.Y >= min && p.Y <= max));
            IEnumerable<CavePosition> swRange = Enumerable.Range(0, bottomPoint.X - leftPoint.X).Select(i => new CavePosition(leftPoint.X + i, leftPoint.Y - i)).Where(p => (p.X >= min && p.X <= max) && (p.Y >= min && p.Y <= max));
            IEnumerable<CavePosition> seRange = Enumerable.Range(0, rightPoint.X - bottomPoint.X + 1).Select(i => new CavePosition(bottomPoint.X + i, bottomPoint.Y + i)).Where(p => (p.X >= min && p.X <= max) && (p.Y >= min && p.Y <= max));

            IEnumerable<CavePosition> fullRange = nwRange.Union(neRange).Union(swRange).Union(seRange);

            return fullRange;
        }
    }
}
