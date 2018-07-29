using System;
namespace KimTower.Data
{
    public class StairCase
    {
        public int BottomFloor { get; set; }

        public int TopFloor { get; set; }

        public StairCase(int bottom)
        {
            this.BottomFloor = bottom;
            this.TopFloor = bottom + 1;
        }


    }
}
