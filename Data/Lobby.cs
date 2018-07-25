using System;
using System.Collections.Generic;

namespace KimTower.Data
{
    public class Lobby : IRoom
    {
        public List<Person> People { get; set; }

        public int Segments { get; set; }

        public Lobby(int segments)
        {
            this.Segments = segments;
        }

    }
}
