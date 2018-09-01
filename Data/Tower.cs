
namespace KimTower.Data
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using KimTower.Data.Floors;
    using KimTower.Data.Transportation.Elevators;

    public class Tower
    {
        public List<IFloor> Floors { get; set; }

        public Ledger Ledger { get; set; }

        public int Population { get; set; }

        public Rating Rating { get; set; }

        public Dictionary<string, Elevator> Elevators { get; set; }

        public Tower()
        {
            this.Floors = new List<IFloor>();
            this.Ledger = new Ledger(0, 0);
            this.Rating = new Rating();
            this.Elevators = new Dictionary<string, Elevator>();
        }

        public void UpdateLedgerByFloor()
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
                if (Floors[i].Transportations.Count > 0)
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
            {//don't need to check lobby
                 foreach (var floor in this.Floors)
                {
                    foreach (var room in  floor.Rooms)
                    {
                        if (room is IRentable && room.Occupied)
                        {
                            floor.Ledger.TotalProfit += ((IRentable)room).PayRent();
                        }


                    }
                }
            }

        }
        public void AddFloor(IFloor floor)
        {
            this.Floors.Insert(this.Floors.Count, floor);
        }

        public IFloor GetParentFloor(IFloor floor)
        {
            if (this.Floors.IndexOf(floor) == 0)
            {
                return null;
            }
            if (this.Floors.Count < (this.Floors.IndexOf(floor) - 1))
            {
                return null;
            }
            return this.Floors[(this.Floors.IndexOf(floor) - 1)];

        }

        public bool IsNextFloorNumber(int requestedNumber) => (requestedNumber == this.Floors.Count);

        public bool IsLobbyBuilt()
        {
            return this.Floors.Count > 0;

        }

        public void UpdatePopulation(int roomPopulation)
        {
            this.Population += roomPopulation;
        }

        public bool IsExistingElevator(int floorNumber, Range range)
        {
            return (this.Floors[floorNumber].Transportations.ContainsKey(range));
        }

        public void AddElevator(Elevator elevator)
        {
            var key = CreateKey(elevator.Range, elevator.BottomFloor, elevator.TopFloor);
            this.Elevators.Add(key, elevator);
        }

        public string CreateKey(Range range, int bottomFloor, int topFloor)
        {
            return "e" + bottomFloor.ToString() + topFloor.ToString() +
                              range.StartX.ToString() + range.EndX.ToString();
        }
    }
}
