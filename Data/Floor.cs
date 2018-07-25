
namespace KimTower.Data
{
    using System.Collections.Generic;

    public class Floor
    {
        public List<IRoom> Rooms { get; set; }

        public int Segemts { get; set; }

        public int FloorNumber { get;  }

        public Floor(int segments)
        {
            this.Rooms = new List<IRoom>();
            this.Segemts = segments;
            this.FloorNumber = 1;
        }

       
    }
}