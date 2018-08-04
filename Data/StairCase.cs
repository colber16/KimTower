using System;
namespace KimTower.Data
{
    public class StairCase
    {
        public int BottomFloor { get; set; }

        public int TopFloor { get; set; }

        public StairCase(int bottomFloor)
        {
            this.BottomFloor = bottomFloor;
            this.TopFloor = bottomFloor + 1;
        }


    }
}
