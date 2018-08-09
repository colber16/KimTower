
namespace KimTower.Data
{
    public static class FloorValidation
    {
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

        public static bool IsValidSpaceOnMap(Range range, int floorNumber)
        {
            if (range.StartX >= 0 && range.EndX<= 500)
            {
                if (floorNumber >= -10 && floorNumber <= 100)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool IsRoomValidForFloor(IRoom room, int floorNumber)
        {
            if (floorNumber == 1)
            {
                if (room is Lobby)
                {
                    return true;
                }
                return false;
            }
            if (!(room is Lobby))
            {
                return true;
            }
            return false;
        }



        
    }
}
