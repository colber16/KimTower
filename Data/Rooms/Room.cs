﻿namespace KimTower.Data
{
    using System.Collections.Generic;

    public abstract class Room : IRoom
    {
        public List<Person> People { get; set; }

        public int Segments { get; private set; }

        public Range Range { get; set; }

        public int Cost { get; }

        public bool Occupied { get; set; }

        public int FloorNumber { get; set; }

        protected Room(int segments, int cost, int x, int floorNumber)
        {
            this.People = new List<Person>();
            this.Segments = segments;
            this.Cost = cost;
            this.Range = new Range(x, x + segments);
            this.FloorNumber = floorNumber;

            //this.Position= new Position(x, x + this.Segments, floorNumber);
        }


        public void SetOccupancy(Tower tower)
        {
            if (tower.HasFirstFloorAccess(this.FloorNumber))
            {
                this.Occupied = true;
            }

        }
    }
}   