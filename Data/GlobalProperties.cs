
namespace KimTower.Data
{
    using KimTower.Data.Rooms;

    public class GlobalProperties
    {
        static int startingBalance = 2000000;

        public int Money { get; private set; }

        public Time Time { get; set; }

       // public MapWindow MapWindow { get; set; }

        public int Rating { get; set; }

        public int Population { get; set; }

        public GlobalProperties()
        {
            this.Money = startingBalance;
        }

        public void SubtractCostForStructures(StructureTypes structure)
        {
            this.Money -= StructureInfo.AllTheInfo[structure].Cost;
        }

        public void AddIncome(Tower tower)
        {
            this.Money += tower.Ledger.TotalProfit;
        }

        public void SubtractCostForMaintenance(Tower tower)
        {
            this.Money -= tower.Ledger.TotalCost;
        }
    }
}
