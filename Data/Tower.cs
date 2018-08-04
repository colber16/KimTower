
namespace KimTower.Data
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Tower
    {
        public List<Floor> Floors { get; set; }

        public Ledger Ledger { get; set; }

        public bool HasLobby { get; set; }

        public Tower()
        {
            this.Floors = new List<Floor>();
            this.Ledger = new Ledger();
            this.HasLobby = false;
        }

        public void UpdateLedger()
        {
            foreach (var floor in this.Floors)
            {
                this.Ledger += floor.Ledger;
            }

        }

        public bool HasFirstFloorAccess(int floorNumber)
        {
            //Floors should be in order.
            this.Floors.OrderByDescending(f => f.FloorNumber);
            var stairCount = 0;

            for (int i = floorNumber; i >= 1; i--)
            {
                //floors need to be set to index number
                if (Floors[i - 1].Stairs.Count > 0)
                {
                    stairCount++;
                    if (stairCount == 0)
                    {
                        return false;
                    }
                }
                Console.WriteLine("No Access to first floor.");
            }
            return stairCount == floorNumber;
        }

        public Floor GetExistingFloor(int floorNumber)
        {
            foreach (var existingFloor in this.Floors)
            {
                if (existingFloor.FloorNumber == floorNumber)
                {
                    return existingFloor;
                }
            }
            return null;
        }

        public void CollectRent(Time time)
        {
            if (time.Day == Day.WeekdayTwo)
            {
                foreach (var floor in this.Floors)
                {
                    foreach (var room in floor.Rooms)
                    {
                        if (room is Office)
                        {
                            ((Office)room).IsOccupied(this);
                            if (((Office)room).Occupied)
                            {
                                floor.Ledger.TotalProfit += ((Office)room).PayRent();
                            }

                        }
                    }
                }
            }
            this.UpdateLedger();
        }

        public void AddFloor(Floor floor)
        {
            this.Floors.Add(floor);
            floor.IsPreexisting = true;
        }
    }
}
