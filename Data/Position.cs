using System;
namespace KimTower.Data
{
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


     

    }
}
