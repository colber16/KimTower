
namespace KimTower.Data
{

    public class GlobalProperties
    {
        static int startingBalance = 2000000;

        public int Money { get; private set; } = startingBalance;

        public Time Time { get; set; }

       // public MapWindow MapWindow { get; set; }

        public int Rating { get; set; }

        public void SubtractConstructionCosts(int cost)
        {
            Money -= cost;
        }

        public  void AddIncome(int profits)
        {
            Money += profits;
        }

        public  void SubtractMaintenanceCosts(int costs)
        {
            Money -= costs;
        }

    }
}
