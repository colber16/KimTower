using System;
using System.Collections.Generic;

namespace KimTower.Data
{
    public class Lobby : IRoom
    {
        int segments = 4;
        public List<Person> People { get; set; }

        public int Segments { get; private set; }

        public int TotalSegments { get; private set; }

        public int Rent => 0;

        public Lobby()
        {
            this.Segments = segments;
            this.TotalSegments = segments;
        }
        public void ExtendSegments()
        {
            this.TotalSegments += segments;
        }

    }
}
