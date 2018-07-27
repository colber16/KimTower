namespace KimTower.Data
{
    public class Ledger
    {
        public int TotalProfit { get; set; }

        public int TotalCost { get; set; }

        public Ledger()
        {
            this.TotalCost = 0;
            this.TotalProfit = 0;
        }
    }

}