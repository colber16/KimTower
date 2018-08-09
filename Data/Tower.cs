
namespace KimTower.Data
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Tower
    {
        public List<IFloor> Floors { get; set; }

        public Ledger Ledger { get; set; }

        public Tower()
        {
            this.Floors = new List<IFloor>();
            this.Ledger = new Ledger();
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

        public IFloor GetExistingFloor(int floorNumber)
        {
            foreach (var existingFloor in this.Floors)
            {
                if (this.Floors.IndexOf(existingFloor) == floorNumber)
                {
                    return existingFloor;
                }
            }
            return null;
        }

        public bool IsValidExistingFloorNumber(int floorNumber)
        {
            return this.Floors.Count != 0 && this.Floors.Count > floorNumber;
        }


        public void CollectRent(Time time)
        {
            if (time.Day == Day.WeekdayTwo)
            {
                 foreach (var floor in this.Floors)
                {
                    foreach (var room in  floor.Rooms)
                    {
                        //should be elsewhere
                        room.SetOccupancy(this, this.Floors.IndexOf(floor));

                        if (room.Occupied)
                        {
                            floor.Ledger.TotalProfit += ((Office)room).PayRent();
                        }


                    }
                }
            }
            this.UpdateLedger();
        }
        public void AddFloor(IFloor floor)
        {
            this.Floors.Insert(this.Floors.Count, floor);
        }

        public IFloor GetParentFloor(IFloor floor)
        {
            if (!(this.Floors.IndexOf(floor) == 0))
            {
                return null;
            }
            if (this.Floors.Count < (this.Floors.IndexOf(floor) - 1))
            {
                return null;
            }
            return this.Floors[(this.Floors.IndexOf(floor)- 1)];

        }

        public bool IsNextFloorNumber(int requestedNumber) => (requestedNumber == this.Floors.Count);

        public bool IsLobbyBuilt()
        {
            return this.Floors.Count > 0;

        }
    }
}
