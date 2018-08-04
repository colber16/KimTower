
namespace KimTower.Data
{
    public static class FloorValidation
    {
        public static bool IsFloorPositionPreexisting(Position position, Floor floor)
        {
            if (position.X >= floor.Position.X)
            {
                if (position.X2 <= floor.Position.X2)
                {
                    return false;
                }
            }
            return true;
        }

        public static bool IsValidPositionOnMap(Position position)
        {
            if (position.X >= 0 && position.X2 <= 500)
            {
                if (position.FloorNumber >= -10 && position.FloorNumber <= 100)
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
