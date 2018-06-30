namespace KimTower
{
    using System;

    public struct Range
    {
        public Range(int xCoordinate, int xSecondCoordinate)
        {
            this.XCoordinate = xCoordinate;
            this.XSecondCoordinate = xSecondCoordinate;
        }

        public int XCoordinate { get; set; }

        public int XSecondCoordinate { get; set; }

        public Range GetPosition()
        {
            throw new NotImplementedException();
        }
    }
}