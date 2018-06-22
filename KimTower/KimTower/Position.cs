namespace KimTower
{
    public struct Position
    {
        public Position(int xCoordinate, int yCoordinate)
        {
            this.XCoordinate = xCoordinate;
            this.YCoordinate = yCoordinate;
        }

        public int XCoordinate { get; set; }

        public int YCoordinate { get; set; }
    }
}