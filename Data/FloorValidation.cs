
namespace KimTower.Data
{
    public static class FloorValidation
    {
        public static bool IsValidPositionInExistingFloor(int x, int x2, Floor floor)
        {
            var count = 0;

            for (int i = floor.Position.X; i <= floor.Position.X2; i++)
            {
                if (x >= i)
                {
                    count++;
                }
                if (count > 0)
                {
                    i = floor.Position.X2;
                }
                if (x2 <= i)
                {
                    count++;
                }
            }
            if (count >= 2)
            {
                return false;
            }
            return true;
        }

        public static bool IsValidPositionOnMap(int x,int x2, int floorNumber)
        {
            if (x >= 0 && x2 <= 500)
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
