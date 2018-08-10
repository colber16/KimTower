
namespace KimTower.Data
{
    using KimTower.Data.Rooms;

    public class StairCase
    {
        static int segments = StructureInfo.stairCaseInfo.Segments;
        static int cost = StructureInfo.stairCaseInfo.Cost;

        public int BottomFloor { get; set; }

        public int TopFloor { get; set; }

        public int Segememts => segments;

        public int Cost => cost;

        public StairCase(int bottomFloor)
        {
            this.BottomFloor = bottomFloor;
            this.TopFloor = bottomFloor + 1;
        }


    }
}
