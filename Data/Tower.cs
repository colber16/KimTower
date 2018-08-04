
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
        //first floor acces should be assigned to flag on floor?
        public bool HasFirstFloorAccess(int floorNumber)
        {
            var stairCount = 0;

            for (int i = 0; i < floorNumber; i++)
            {
                //floors need to be set to index number
                if (Floors[i].Stairs.Count > 0)
                {
                    stairCount++;
                    if (stairCount == 0)
                    {
                        Console.WriteLine("No Access to first floor.");
                        return false;
                    }
                }

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
                            ((Room)room).SetOccupancy(this);
                            if (((Room)room).Occupied)
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
