
namespace KimTower.Data.Rooms
{
    using System;
    using System.Collections.Generic;
    using KimTower.Data.Rooms;

    public class Restaurant : Room, IRoom
    {
        static int segments = StructureInfo.restaurantInfo.Segments;
        static int cost = StructureInfo.restaurantInfo.ConstructionCost;

        //this can change, in the future.
        int rent = 3000;
        static int population = 10;

        public int Rent => rent;

        public Restaurant(int x, int floorNumber) : base(segments, cost, x, floorNumber, population)
        {
           

        }
        public int PayRent()
        {
            //paid every weekday2
            return this.Rent;
        }

    }
}

