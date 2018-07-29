
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


        public int PayRent()
        {
            //paid every weekday2
            return this.Rent;
        }
       
    }
}
