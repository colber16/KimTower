
namespace KimTower.Data
{
    using System;
    using System.Collections.Generic;

    public class Tower
    {
        public List<Floor> Floors { get; set; }

        public Ledger Ledger { get; set; }

        public Tower()
        {
            this.Floors = new List<Floor>();
            this.Ledger = new Ledger();
        }

        public void UpdateLedger()
        {
            foreach (var floor in this.Floors)
            {
                this.Ledger += floor.Ledger;
            }
        }
    }
}
