using System;
namespace KimTower
{

    public interface IRoom
    {
        /// <summary>
        /// Is room being rented or lived in.
        /// </summary>
        /// <value><c>true</c> if occupied; otherwise, <c>false</c>.</value>
        bool Occupied { get; set; }

        //int MaintenanceCost { get; set; }
        /// <summary>
        /// Gets the capacity. Which is used in tower population
        /// </summary>
        /// <value>The capacity.</value>
        int Capacity { get; }
        /// <summary>
        /// Current population of people.
        /// </summary>
        /// <value>The population.</value>
        int Population { get; set; }

        bool IsLit { get; set; }

        //int ConstructionCost { get; set; }

        Range Range { get;  }

        int FloorNumber { get; set; }

        //int Revenue { get; set; }

        int Segements { get; }
       

    }
    /// <summary>
    /// Waiting rooms for transportation.
    /// </summary>
    public class WaitingRoom : IRoom
    {
        private int capacity = 32;//Random number

        public bool Occupied { get; set; } //doesn't really apply

        public int Capacity => capacity;

        public int Population { get; set; } 

        public bool IsLit { get; set; } //doesn't really apply

        //int ConstructionCost { get; set; }

        public Range Range { get; }

        public int FloorNumber { get; set; }

        //int Revenue { get; set; }

        public int Segements => this.Range.XSecondCoordinate - this.Range.XCoordinate;

        public WaitingRoom(Range floorRange, IElevator transpo)
        {
            this.FloorNumber = transpo.Elevator.FloorSpan.BottomFloor;
            this.Range = new Range(floorRange.XCoordinate, floorRange.XSecondCoordinate);
           // this.Population = GetPopulation(time);
        }
       
        private Range GetRange(Floor floor, int x)
        {
            if(x < 0)
            {
                return new Range(floor.Range.XCoordinate, x);
            }
            return new Range(x, floor.Range.XSecondCoordinate);

        }

        public int GetPopulation => 0;
        //private int GetPopulation(Time time)
        //{
        //    if(time.GetTrafficFromMinutes(time.TotalMinutes) == Traffic.Busy)
        //    {
        //        return capacity;
        //    }
        //    if (time.GetTrafficFromMinutes(time.TotalMinutes) == Traffic.Medium)
        //    {
        //        return capacity / 2;
        //    }
        //    else
        //    {
        //        return 0; 
        //    }

        //}
    }

    public class Office : IRoom
    {
        private int segments = 9;
        private int capacity = 6;
        private int xSecondCooridnate = 0;
       
        public bool Occupied { get; set; } // is there transportation.  Are conditions good?
        public int Capacity => capacity;
        public int Population { get; set; } // set by time
        public bool IsLit { get; set; } //set by time
        public Range Range { get; }
        public int FloorNumber { get; set; }

        public int Segements => segments;

        public Office(Floor floor)
        {
            this.FloorNumber = floor.FloorNumber;
            this.Range = GetRange();

        }

        private Range GetRange() => new Range(this.xSecondCooridnate, this.xSecondCooridnate + segments);

    }

    public class Condo //: IRoom
    {
        private int segments = 9;
        private int capacity = 6;
       
    }

}

