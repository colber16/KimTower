
namespace KimTower.Data
{
    using System;
    using System.Collections.Generic;

    public static class FloorValidation
    {
        //put this here b/c I thought I might use it in room classes
        //though it seems janky.
        public static Dictionary<StructureTypes, int> structureSegments = new Dictionary<StructureTypes, int>
        {
            {StructureTypes.Lobby, 4},
            {StructureTypes.Office, 6},
            {StructureTypes.StairCase, 6},
            {StructureTypes.Restaurant, 10},
            {StructureTypes.Condo, 8}

        };

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
