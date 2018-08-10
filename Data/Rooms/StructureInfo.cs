
namespace KimTower.Data.Rooms
{
    using System;
    using System.Collections.Generic;

    public static class RoomInfo
    {
       
        public static Dictionary<StructureTypes, int> structureSegments = new Dictionary<StructureTypes, int>
        {
            {StructureTypes.Lobby, 4},
            {StructureTypes.Office, 6},
            {StructureTypes.StairCase, 6},
            {StructureTypes.Restaurant, 10},
            {StructureTypes.Condo, 8}

        };
    }
}
