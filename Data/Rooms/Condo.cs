namespace KimTower.Data
{
    using System.Collections.Generic;

    public class Condo : Room, IRoom
    {
        //.........
        static int segments = FloorValidation.structureSegments[StructureTypes.Lobby];
        static int cost = 100000;
        int salePrice = 300000;

        public int SalePrice => salePrice;

        public Condo(int x, int floorNumber): base(segments, cost, x, floorNumber)
        {
            
        }
    }
}