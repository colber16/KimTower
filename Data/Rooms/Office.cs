
namespace KimTower.Data
{
    using System;
    using System.Collections.Generic;

    public class Office : Room, IRoom
    {
        static int segments = 6;
        int rent = 1000;
        static int cost = 10000;

        public int Rent => rent;

        public Office(int x, int floorNumber) : base(segments, cost, x, floorNumber)
        {

        }


        public int PayRent()
        {
            //paid every weekday2
            return this.Rent;
        }
       
    }
}
