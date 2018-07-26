
namespace KimTower.Data
{
    using System;
    using System.Collections.Generic;

    public class Office : IRoom 
    {
        int segments = 6;
        public List<Person> People { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int Segments { get;  }

        public Office()
        {
            this.Segments = segments;
        }
       
    }
}
