namespace KimTower.Data
{
    using System.Collections.Generic;

    public class Condo : IRoom
    {

        int segments = 8;
        int salePrice = 300000;
        int cost = 100000;

        public List<Person> People { get; set; }

        public int Segments { get; }

        public bool Occupied { get; set; }

        public int Cost => cost;

        public Position Position { get; set; }


        public Condo(int x, int floorNumber)
        {
            this.Segments = segments;
            this.People = new List<Person>();
            this.Position = new Position(x, x + segments, floorNumber);

        }

        public void SetOccupancy(Tower tower)
        {
            if (tower.HasFirstFloorAccess(this.Position.FloorNumber))
            {
                this.Occupied = true;
            }

        }
    }
}