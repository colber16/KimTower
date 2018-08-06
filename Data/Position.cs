
namespace KimTower.Data
{
    using System;

    public struct Position
    {
        public Range Range { get; set; }
        public int FloorNumber { get; set; }

        public Position(Range range, int floorNumber)
        {
            this.Range = range;
            this.FloorNumber = floorNumber;
        }


        public static bool ArePositionsSameFloor(Position p1, Position p2)
        {
            return p1.FloorNumber == p2.FloorNumber;
        }
    }
}
