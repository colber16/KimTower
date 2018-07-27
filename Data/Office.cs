
namespace KimTower.Data
{
    using System;
    using System.Collections.Generic;

    public class Office : IRoom 
    {
        int segments = 6;
        int rent = 1000;

        public List<Person> People { get ; set ; }

        public int Segments { get;  }

        public int Rent => rent;

        public Office()
        {
            this.Segments = segments;
        }
        public int PayRent()
        {
            //every month 
            //time
            return this.Rent;
        }
       
    }
}
