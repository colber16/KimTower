
namespace KimTower.Data
{

    public static class GlobalProperties
    {
        static int startingBalance = 2000000;

        public static int Money { get; private set; } = startingBalance;

        public static Time Time { get; set; }

       // public MapWindow MapWindow { get; set; }

        public static int Rating { get; set; }

        //public GlobalProperties()
        //{
        //    this.Money = startingBalance;
        //}

        public static void SubtractConstructionCosts(StructureTypes structure, int numberOfSegments = 1)
        {
            Money -= StructureInfo.AllTheInfo[structure].ConstructionCost * numberOfSegments;
        }

        public static void AddIncome(int profits)
        {
            Money += profits;
        }

        public static void SubtractMaintenanceCosts(int costs)
        {
            Money -= costs;
        }

    }
}
