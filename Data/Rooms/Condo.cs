namespace KimTower.Data
{
    using System.Collections.Generic;

    public class Condo : Room, IRoom
    {

        static int segments = 8;
        static int cost = 100000;
        int salePrice = 300000;

        public int SalePrice => salePrice;

        public Condo(int x, int floorNumber): base(segments, cost, x, floorNumber)
        {
            
        }
    }
}