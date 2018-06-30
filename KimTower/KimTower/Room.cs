using System;
namespace KimTower
{
    /// <summary>
    /// Room.
    /// </summary>
    public interface IRoom
    {

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

        int IsLit { get; set; }

        //int ConstructionCost { get; set; }

        Range Range { get; set; }

        int FloorNumber { get; set; }

        //int Revenue { get; set; }

        int Segements { get; }
       

    }
    /// <inheritdoc/>
    public class Office : IRoom
    {
        private int segments = 9;
        private int capacity = 6;
       
        public bool Occupied { get; set; }
        public int Capacity => capacity;
        public int Population { get; set; } // set by time?
        public int IsLit { get; set; } //set by time
        public Range Range { get; set; }
        public int FloorNumber { get; set; }

        public int Segements => segments;

        public Office(Floor floor, Range range)
        {
            this.FloorNumber = floor.FloorNumber;
            this.Range = range;

        }
    }

}
