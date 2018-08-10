namespace KimTower.Data.Rooms
{
    using System.Collections.Generic;
    using KimTower.Data.Rooms;

    public class Condo : Room, IRoom
    {
        
        static int segments = StructureInfo.condoInfo.Segments;
        static int cost = StructureInfo.condoInfo.Cost;
        int salePrice = 300000;

        public int SalePrice => salePrice;

        public Condo(int x, int floorNumber): base(segments, cost, x, floorNumber)
        {
            
        }
    }
}