
namespace KimTower.Data
{
    using System;
    using System.Collections.Generic;

    public class Office : IRoom, IRentable
    {
        int segments = 6;
        int rent = 1000;
        int cost = 10000;

        public List<Person> People { get ; set ; }

        public int Segments { get;  }

        public int Rent => rent;

        public bool Occupied { get; set; }

        public int Cost => cost;

        public Position Position { get; set; }

        public Office()
        {
            this.Segments = segments;
            this.People = new List<Person>();

        }
        public Office(int x, int floorNumber)
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

        public int PayRent()
        {
            //paid every weekday2
            return this.Rent;
        }
       
    }
}
