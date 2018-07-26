
namespace KimTower.Data
{
    using System;
    using System.Collections.Generic;

    public class Floor
    {
        public List<IRoom> Rooms { get; set; }

        public int Segments { get; set; }

        public int FloorNumber { get; set; }

        public Floor(int segments, int floorNumber)
        {
            this.Rooms = new List<IRoom>();
            this.Segments = segments;
            this.FloorNumber = floorNumber; 
        }

        public void ExtendSegments(int segments)
        {
            this.Segments += segments;
        }

    }
}