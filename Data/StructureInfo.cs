
namespace KimTower.Data
{
    using System;
    using System.Collections.Generic;

    public static class StructureInfo
    {
        public static readonly StructureTypeInfo restaurantInfo = new StructureTypeInfo(10, 30000);
        public static readonly StructureTypeInfo officeInfo = new StructureTypeInfo(6, 40000);
        public static readonly StructureTypeInfo condoInfo = new StructureTypeInfo(16, 80000);
        public static readonly StructureTypeInfo lobbyInfo = new StructureTypeInfo(4, 20000);
        public static readonly StructureTypeInfo stairCaseInfo = new StructureTypeInfo(8, 5000);
        public static readonly StructureTypeInfo floorInfo = new StructureTypeInfo(1, 500);

        public static Dictionary<StructureTypes, StructureTypeInfo> AllTheInfo = new Dictionary<StructureTypes, StructureTypeInfo>
        {
            {StructureTypes.Lobby, lobbyInfo},
            {StructureTypes.Floor, floorInfo},
            {StructureTypes.Office, officeInfo},
            {StructureTypes.StairCase, stairCaseInfo},
            {StructureTypes.Restaurant, restaurantInfo},
            {StructureTypes.Condo, condoInfo}

        };

        public static int GetUnpaidSegments(Range unpaidRange, StructureTypes floorType)
        {
            int segments = unpaidRange.GetSegments();

            if (floorType is StructureTypes.Lobby)
            {
                segments = segments / 4;
            }
            return segments;

        }
    }

    public class StructureTypeInfo
    {
        public int Segments { get; private set; }

        public int ConstructionCost { get; private set; }

        public int MaintenanceCost { get; private set; }

        public StructureTypeInfo(int segments, int constructionCost)
        {
            this.Segments = segments;
            this.ConstructionCost = constructionCost;
        }
    }


}
