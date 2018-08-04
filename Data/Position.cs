
namespace KimTower.Data
{
    using System;

    public struct Position
    {
        public int X { get; set; }
        public int X2 { get; set; }
        public int FloorNumber { get; set; }

        public Position(int x, int x2, int floorNumber)
        {
            this.X = x;
            this.X2 = x2;
            this.FloorNumber = floorNumber;
        }
        public static Position operator +(Position p1, Position p2)
        {
            if(p1.FloorNumber != p2.FloorNumber)
            {
                throw new ArgumentException();
            }

            return new Position(p1.X + p2.X, p1.X2 + p2.X2, p1.FloorNumber);

        }

        public static (Position? p1, Position? p2) operator -(Position p1, Position p2)
        {
            bool equalX = false;
            bool equalX2 = false;

            if (p1.FloorNumber != p2.FloorNumber)
            {
                throw new ArgumentException();
            }

            if (p1.X == p2.X)
            {
                equalX = true;
            }

            if (p1.X2 == p2.X2)
            {
                equalX2 = true;
            }

            if(equalX && equalX2)
            {
                return (new Position?(p1.X, p1.X2, p1.FloorNumber), null);
            }

            if (p1.X < p2.X)
            {
                if(equalX2)
                {
                    return (new Position?(p1.X, p2.X, p1.FloorNumber), null);
                }
                if (p1.X2 > p2.X2)
                {
                    return (new Position?(p1.X, p2.X, p1.FloorNumber), new Position?(p2.X2, p1.X2, p1.FloorNumber));
                }

            }
            if(equalX)
            {
                return (new Position?(p2.X2, p1.X2, p1.FloorNumber), null);
            }
            //should be checking if p1.x is greaterthan p2.x before this method
             
            return (null, null);

        }

        public static bool ArePositionsSameFloor(Position p1, Position p2)
        {
            return p1.FloorNumber == p2.FloorNumber;
        }
    }
}
