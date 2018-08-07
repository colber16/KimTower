
namespace KimTower.Data
{
    using System;
    using System.Collections.Generic;

    public class Restaurant : Room, IRoom
    {
        static int segments = 10;
        static int cost = 30000;
        int rent = 3000;

        public int Rent => rent;

        public Restaurant(int x, int floorNumber) : base(segments, cost, x, floorNumber)
        {
           

        }
        public int PayRent()
        {
            //paid every weekday2
            return this.Rent;
        }

    }
}

