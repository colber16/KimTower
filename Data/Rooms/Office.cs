
namespace KimTower.Data
{
    using System;
    using System.Collections.Generic;
    using KimTower.Data.Rooms;

    public class Office : Room, IRoom
    {
        static int segments = StructureInfo.officeInfo.Segments;
        int rent = 1000;
        static int cost = StructureInfo.officeInfo.Cost;

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
