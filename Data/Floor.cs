
namespace KimTower.Data
{
    using System;
    using System.Collections.Generic;

    public class Floor
    {
        public List<IRoom> Rooms { get; set; }

        public int Segments { get; set; }

        public int FloorNumber { get;  }

        public Floor(int segments)
        {
            this.Rooms = new List<IRoom>();
            this.Segments = segments;
            this.FloorNumber = 1;
        }

        public void ExtendSegments(int segments)
        {
            this.Segments += segments;
        }
    }
}