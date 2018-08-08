
namespace KimTower.Data
{
    using System;
    using System.Linq;
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

        public bool IsValidExistingFloorNumber(int floorNumber)
        {
            if (this.Floors.Count != 0)
            {
                foreach (var existingFloor in this.Floors)
                {
                    if (existingFloor.FloorNumber == floorNumber)
                    {
                        return true;
                    }
                }
            }
            return false;
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
            floor.FloorNumber = Floors.IndexOf(floor) + 1;
            floor.IsPreexisting = true;
        }

        public Floor GetParentFloor(int floorNumber)
        {
            if (!(floorNumber > 1))
            {
                return null;
            }
            if(this.Floors.Count < floorNumber - 1)
            {
                return null;
            }
            return this.Floors[floorNumber - 2];

        }

        public int SetFloorNumber() => this.Floors.Count + 1;

        public bool IsNextFloorNumber(int requestedNumber) => (requestedNumber == SetFloorNumber());

        public bool HasLobby()
        {
            if(this.Floors.Count > 0)
            {
                return (this.Floors[0].Rooms.Any(l => l.Equals(StructureTypes.Lobby))) ;
            }
            return false;
        }
    }

}
