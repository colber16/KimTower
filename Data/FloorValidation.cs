
namespace KimTower.Data
{
    public static class FloorValidation
    {
        public static bool IsLobbyFloor(int floorNumber) => floorNumber == 0;

        public static bool IsFloorRangePreexisting(Range range, IFloor floor)
        {
            if (range.StartX >= floor.Range.StartX)
            {
                if (range.EndX >= floor.Range.EndX)
                {
                    return false;
                }
            }
            return true;
        }

        public static bool IsValidRangeOnMap(Range range) => (range.StartX >= 0 && range.EndX <= 500);


        public static bool IsValidFloorForMap( int floorNumber) => (floorNumber >= -10 && floorNumber <= 100);


    }
}
