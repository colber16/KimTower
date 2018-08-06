
namespace KimTower.Data
{
    public static class FloorValidation
    {
        //public static bool IsFloorPositionPreexisting(Position position, Floor floor)
        //{
        //    if (position.X >= floor.Position.X)
        //    {
        //        if (position.X2 <= floor.Position.X2)
        //        {
        //            return false;
        //        }
        //    }
        //    return true;
        //}

        public static bool IsValidRangeOnMap(Range range, int floorNumber)
        {
            if (range.StartX >= 0 && range.EndX <= 500)
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
            if ((room is Lobby))
            {
                return false;
            }
            return true;
        }
    }
}
