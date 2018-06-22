namespace KimTower
{
    using System;

    public struct Position
    {
        public Position(int xCoordinate, int yCoordinate, int xSecondCoordinate, int ySecondCoordinate)
        {
            this.XCoordinate = xCoordinate;
            this.YCoordinate = yCoordinate;
            this.XSecondCoordinate = xSecondCoordinate;
            this.YSecondCoordinate = ySecondCoordinate;
        }

        public int XCoordinate { get; set; }

        public int YCoordinate { get; set; }

        public int XSecondCoordinate { get; set; }

        public int YSecondCoordinate { get; set; }

        public Position GetPosition()
        {
            throw new NotImplementedException();
        }
    }
}