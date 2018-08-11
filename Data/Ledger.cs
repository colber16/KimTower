namespace KimTower.Data
{
    public class Ledger
    {
        public int TotalProfit { get; set; }

        public int TotalCost { get; set; }

        public Ledger(int profit, int cost)
        {
            this.TotalProfit = profit;
            this.TotalCost = cost;
        }

        public static Ledger operator + (Ledger l1, Ledger l2)
        {
            var totalProfit = l1.TotalProfit + l2.TotalProfit;
            var totalCost = l1.TotalCost + l2.TotalCost;
            return new Ledger(totalProfit, totalCost);
        }
    }

}