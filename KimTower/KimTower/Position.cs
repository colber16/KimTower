namespace KimTower
{
    using System;

    public struct Position
    {
        public Position(int xCoordinate, int xSecondCoordinate)
        {
            this.XCoordinate = xCoordinate;
            this.XSecondCoordinate = xSecondCoordinate;
        }

        public int XCoordinate { get; set; }

        public int XSecondCoordinate { get; set; }

        public Position GetPosition()
        {
            throw new NotImplementedException();
        }
    }
}