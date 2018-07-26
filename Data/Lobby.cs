using System;
using System.Collections.Generic;

namespace KimTower.Data
{
    public class Lobby : IRoom
    {
        int segments = 4;
        public List<Person> People { get; set; }

        public int Segments { get; private set; }

        public int StandardSegments { get; private set; }

        public Lobby()
        {
            this.Segments = segments;
            this.StandardSegments = segments;
        }
        public void ExtendSegments()
        {
            this.Segments += segments;
        }

    }
}
