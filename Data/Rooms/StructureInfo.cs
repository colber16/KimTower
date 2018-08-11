
namespace KimTower.Data.Rooms
{
    using System;
    using System.Collections.Generic;

    public static class StructureInfo
    {
        public static readonly StructureTypeInfo restaurantInfo = new StructureTypeInfo(10, 30000);
        public static readonly StructureTypeInfo officeInfo = new StructureTypeInfo(6, 40000);
        public static readonly StructureTypeInfo condoInfo = new StructureTypeInfo(8, 100000);
        public static readonly StructureTypeInfo lobbyInfo = new StructureTypeInfo(4, 20000);
        public static readonly StructureTypeInfo stairCaseInfo = new StructureTypeInfo(6, 1000);

        public static Dictionary<StructureTypes, StructureTypeInfo> AllTheInfo = new Dictionary<StructureTypes, StructureTypeInfo>
        {
            {StructureTypes.Lobby, lobbyInfo},
            {StructureTypes.Office, officeInfo},
            {StructureTypes.StairCase, stairCaseInfo},
            {StructureTypes.Restaurant, restaurantInfo},
            {StructureTypes.Condo, condoInfo}

        };
    }

    public class StructureTypeInfo
    {
        public int Segments { get; private set; }

        public int Cost { get; private set; }

        public StructureTypeInfo(int segments, int cost)
        {
            this.Segments = segments;
            this.Cost = cost;
        }
    }
}
